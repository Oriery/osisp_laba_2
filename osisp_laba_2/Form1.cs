using System.Collections;

namespace osisp_laba_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string str = cell.Value.ToString();
            List<string> words = str.Split(' ').ToList<string>();

            int symbolsMax = (int)(2.3f * cell.Size.Width / dataGridView1.Font.Height);
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                if (word.Length > symbolsMax)
                {
                    words[i] = word.Substring(0, symbolsMax);
                    string nextWord = word.Substring(symbolsMax, word.Length - symbolsMax);
                    words.Insert(i + 1, nextWord);
                }
            }

            cell.Value = String.Join(' ', words);
        }
    }
}