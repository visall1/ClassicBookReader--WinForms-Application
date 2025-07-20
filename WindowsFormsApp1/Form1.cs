using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Book selectedBook;
        private string selectedBookContent; 
        private readonly List<Book> books = new List<Book>
        {
            new Book("The Adventures of Tom Sawyer",
                     "https://www.gutenberg.org/files/74/74-0.txt",
                     "https://www.gutenberg.org/cache/epub/74/pg74.cover.medium.jpg"),

            new Book("Pride and Prejudice",
                     "https://www.gutenberg.org/files/1342/1342-0.txt",
                     "https://www.gutenberg.org/cache/epub/1342/pg1342.cover.medium.jpg"),

            new Book("Moby-Dick",
                     "https://www.gutenberg.org/files/2701/2701-0.txt",
                     "https://www.gutenberg.org/cache/epub/2701/pg2701.cover.medium.jpg"),

            new Book("Dracula",
                     "https://www.gutenberg.org/files/345/345-0.txt",
                     "https://www.gutenberg.org/cache/epub/345/pg345.cover.medium.jpg"),

            new Book("Frankenstein",
                     "https://www.gutenberg.org/files/84/84-0.txt",
                     "https://www.gutenberg.org/cache/epub/84/pg84.cover.medium.jpg"),

            new Book("Jane Eyre",
                     "https://www.gutenberg.org/files/1260/1260-0.txt",
                     "https://www.gutenberg.org/cache/epub/1260/pg1260.cover.medium.jpg"),

            new Book("The Picture of Dorian Gray",
                     "https://www.gutenberg.org/files/174/174-0.txt",
                     "https://www.gutenberg.org/cache/epub/174/pg174.cover.medium.jpg"),

            new Book("The Great Gatsby",
                     "https://www.gutenberg.org/files/64317/64317-0.txt",
                     "https://www.gutenberg.org/cache/epub/64317/pg64317.cover.medium.jpg"),

            new Book("War and Peace",
                     "https://www.gutenberg.org/files/2600/2600-0.txt",
                     "https://www.gutenberg.org/cache/epub/2600/pg2600.cover.medium.jpg"),

            new Book("The Odyssey",
                     "https://www.gutenberg.org/files/1727/1727-0.txt",
                     "https://www.gutenberg.org/cache/epub/1727/pg1727.cover.medium.jpg")
        };

        public Form1()
        {
            InitializeComponent();

            PanelMoves.Attach(panel1,this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBookCovers();
        }

        private void LoadBookCovers()
        {
            flowLayoutPanelBooks.Controls.Clear();
            flowLayoutPanelBooks.AutoScroll = true;

            foreach (var book in books)
            {
                var panel = new Panel
                {
                    Width = 120,
                    Height = 200,
                    Margin = new Padding(30,15,0,5),  
                };

                var pb = new PictureBox
                {
                    Width = 120,
                    Height = 170,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand,
                    Tag = book
                };
                pb.LoadAsync(book.CoverUrl);
                pb.Click += BookCover_Click;

                var lbl = new Label
                {
                    Text = book.Title,
                    Width = 140,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    AutoEllipsis = true,
                   
                    
                };

                panel.Controls.Add(pb);
                panel.Controls.Add(lbl);
                flowLayoutPanelBooks.Controls.Add(panel);

            }
        }

        private void CenterTextInRichTextBox(RichTextBox richTextBox)
        {
            string[] lines = richTextBox.Lines;
            richTextBox.Clear(); // Clear existing text

            foreach (var line in lines)
            {
                // Add spaces to each line to simulate centering
                int spacesToAdd = (richTextBox.Width - richTextBox.SelectionLength) / 2;
                string centeredLine = new string(' ', spacesToAdd) + line;
                richTextBox.AppendText(centeredLine + "\n");
            }
        }


        private async void BookCover_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pb && pb.Tag is Book book)
            {
                selectedBook = book;
                button.Enabled = false;

                richTextBoxContent.Text = "Downloading...";
                selectedBookContent = await DownloadBookContentAsync(book.Url);
                richTextBoxContent.Text = selectedBookContent;
                CenterTextInRichTextBox(richTextBoxContent);
                button.Enabled = true;
            }
        }

        private async Task<string> DownloadBookContentAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient()) // Explicit declaration
                {
                    return await client.GetStringAsync(url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Failed to load book.";
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button_Click(object sender, EventArgs e)
        {
            if (selectedBook == null || string.IsNullOrWhiteSpace(richTextBoxContent.Text))
            {
                MessageBox.Show("No book selected or empty content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FileName = $"{selectedBook.Title}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        File.WriteAllText(saveFileDialog.FileName, richTextBoxContent.Text);
                        MessageBox.Show("Book saved successfully!", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
