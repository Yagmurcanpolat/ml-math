using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string? selectedImagePath;
        private const string GEMINI_API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";
        private const string API_KEY = "AIzaSyCoQzrSGIFca7OFVrdug8_k2dIHfoG2dX0";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pictureBox.Image = Image.FromFile(selectedImagePath);
                btnAnalizEt.Enabled = true;
                txtSonuc.Text = "Resim yüklendi. 'Analiz Et ve Çöz' butonuna tıklayın.";
            }
        }

        private async void btnAnalizEt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath) || !File.Exists(selectedImagePath))
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAnalizEt.Enabled = false;
            txtSonuc.Text = "Analiz ediliyor, lütfen bekleyin...";
            Cursor = Cursors.WaitCursor;

            try
            {
                string result = await AnalyzeAndSolveMathProblem(selectedImagePath);
                txtSonuc.Text = result;
            }
            catch (Exception ex)
            {
                txtSonuc.Text = $"Hata oluştu: {ex.Message}";
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAnalizEt.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async Task<string> AnalyzeAndSolveMathProblem(string imagePath)
        {
            // Resmi base64'e çevir
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64Image = Convert.ToBase64String(imageBytes);
            string imageExtension = Path.GetExtension(imagePath).TrimStart('.').ToLower();
            string mimeType = imageExtension switch
            {
                "jpg" or "jpeg" => "image/jpeg",
                "png" => "image/png",
                "gif" => "image/gif",
                "bmp" => "image/bmp",
                _ => "image/jpeg"
            };

            using (HttpClient client = new HttpClient())
            {
                // Gemini API endpoint'i - API key query parameter olarak gönderilir
                string apiUrl = $"{GEMINI_API_URL}?key={API_KEY}";

                // Gemini API request formatı
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new object[]
                            {
                                new
                                {
                                    text = @"Bu resimdeki matematik sorusunu analiz et ve çöz. 
Lütfen şu formatta yanıt ver:
1. SORU TİPİ: [Soru tipini belirtin - örn: İkinci dereceden denklem, İntegral, Limit, vb.]
2. SORU İÇERİĞİ: [Soruyu metin olarak yazın]
3. ÇÖZÜM ADIMLARI: [Adım adım çözümü detaylı olarak açıklayın]
4. CEVAP: [Nihai cevabı belirtin]

Eğer soru çözülemiyorsa veya belirsizse, bunu belirtin."
                                },
                                new
                                {
                                    inlineData = new
                                    {
                                        mimeType = mimeType,
                                        data = base64Image
                                    }
                                }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.4,
                        topK = 32,
                        topP = 1,
                        maxOutputTokens = 4096
                    }
                };

                string jsonContent = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);
                
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API Hatası ({response.StatusCode}): {errorContent}");
                }

                string responseJson = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<JsonElement>(responseJson);

                // Gemini API response formatı
                if (responseObj.TryGetProperty("candidates", out JsonElement candidates) && 
                    candidates.GetArrayLength() > 0)
                {
                    var candidate = candidates[0];
                    if (candidate.TryGetProperty("content", out JsonElement contentObj) &&
                        contentObj.TryGetProperty("parts", out JsonElement parts) &&
                        parts.GetArrayLength() > 0)
                    {
                        var text = parts[0].GetProperty("text").GetString();
                        return text ?? "Yanıt alınamadı.";
                    }
                }

                throw new Exception("API'den beklenmeyen yanıt formatı.");
            }
        }
    }
}
