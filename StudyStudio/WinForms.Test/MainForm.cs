﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void FileUploadButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var name = openFileDialog.SafeFileName;
                var path = openFileDialog.FileName;

                byte[] fileBytes;
                using (FileStream stream = File.OpenRead(path))
                {
                    fileBytes = new byte[stream.Length];
                    stream.Read(fileBytes, 0, fileBytes.Length);
                }

                var multiContent = new MultipartFormDataContent();

                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("multipart/form-data");
                multiContent.Add(fileContent, nameof(UploadFile.File), name);

                multiContent.Add(new StringContent(FileNoNumericUpDown.Value.ToString()), $"{nameof(UploadFile.Info)}.{nameof(UploadFile.Info.No)}");

                multiContent.Add(new StringContent(FileNameTextBox.Text), $"{nameof(UploadFile.Info)}.{nameof(UploadFile.Info.Name)}");

                var httpClient = new HttpClient();

                var httpResponseMessage = await httpClient.PostAsync(new Uri("https://localhost:44390/api/file"), multiContent);

                MessageBox.Show($@"
HTTP STATUS CODE = {httpResponseMessage.StatusCode}
RESPONSE DATA = {await httpResponseMessage.Content.ReadAsStringAsync()}
");
            }
        }
    }

    public class UploadFile
    {
        public FileInfo Info { get; set; }
        public IFormFile File { get; set; }
    }

    public class FileInfo
    {
        public int No { get; set; }
        public string Name { get; set; }
    }
}
