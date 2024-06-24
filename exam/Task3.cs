using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_3
{
    public class Task3
    {
        public class Searcher
        {
            private string textI = "";
            private string textO = "";
            private List<string> palindromes = new List<string>();

            public string Input { get { return textI; } }
            public string Output { get { return textO; } }

            private bool isPalindrome(string input)
            {
                for (int i = 0; i < input.Length / 2; i++)
                {
                    if (input[i] != input[input.Length - i - 1])
                        return false;
                }
                return true;
            }
            public Searcher(string x)
            {
                this.textI = x;

                string buf = "";
                for (int i = 0; i < textI.Length; i++)
                {
                    if (textI[i] == '\n' || textI[i] == ',' || textI[i] == ' ')
                    {
                        if (buf.Length <= 1)
                        {
                            buf = "";
                            continue;
                        }
                        string buf2 = buf.ToLower();
                        if (isPalindrome(buf2))
                        {
                            this.palindromes.Add(buf2);
                        }
                        buf = "";
                    }
                    else
                    {
                        buf += textI[i];
                    }
                }

            }
            public override string ToString()
            {
                string x = "";
                for (int i = 0; i < palindromes.Count; i++)
                {
                    x += palindromes[i].ToString();

                    if (i + 1 < palindromes.Count)
                    {
                        x += "\n";
                    }
                }
                return x;
            }

        }
    }
}
