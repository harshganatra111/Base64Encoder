using System;

namespace Base64
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Enter message to be encrypted");
            String s = Console.ReadLine();
            p.encode(s);
        }
        public void encode(String msg)
        {
            try
            {
                string str = msg.Trim();
                string binary = String.Empty;
                string ascii = String.Empty;
                string base64 = String.Empty;

                int strlen = str.Length;
                int arrsize3by = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(strlen) / 3)); 
                int cnt3by = 0; 
                string[] arr3by = new string[arrsize3by];
                string threebytes = String.Empty;
                int i = 0, index3by = 0, index6b = 0;

                for (i = 0, index3by = 0; i < strlen; ++i)
                {
                    ++cnt3by;

                    int ac = GetASCII(str[i]); 

                    ascii += ac + " "; 

                    string bin = GetBinary(ac); 

                    binary += bin + " "; 

                    threebytes += bin; 

                    if (cnt3by == 3)
                    {
                        arr3by[index3by] = threebytes;
                        threebytes = String.Empty;
                        cnt3by = 0;
                        ++index3by; 
                    }
                }

                if (i == str.Length && cnt3by > 0)
                {
                    arr3by[index3by] = threebytes;
                    threebytes = String.Empty;
                    cnt3by = 0;
                }

                foreach (string s3 in arr3by)
                {
                    int sLen = s3.Length;
                    int arrsize6b = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(sLen) / 6)); 
                    int cnt6b = 0;
                    string[] arr6b = new string[arrsize6b];
                    string sixbits = String.Empty;

                    for (i = 0, index6b = 0; i < sLen; ++i)
                    {
                        ++cnt6b;

                        sixbits += s3[i];

                        if (cnt6b == 6)
                        {
                            arr6b[index6b] = sixbits;
                            sixbits = String.Empty;
                            cnt6b = 0;
                            ++index6b;
                        }
                    }

                    for (; sixbits.Length <= 5;)
                    {
                        sixbits += "0";
                    }
                    if (i == s3.Length && cnt6b > 0)
                    {
                        arr6b[index6b] = sixbits;
                        sixbits = String.Empty;
                        cnt6b = 0;
                    }


                    foreach (string s6 in arr6b)
                    {
                        base64 += GetBase64(s6);
                    }
                }

                msg= base64;
                Console.WriteLine("Base 64 :  "+msg);
                byte[] enc = new byte[msg.Length];
                enc= System.Text.Encoding.UTF8.GetBytes(msg);
                string enc1 = Convert.ToBase64String(enc);
                Console.WriteLine(enc1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

       

        private int GetASCII(char ch)
        {
            int ASCII = (int)ch;

            return ASCII;
        }

        private string GetBinary(int dec)
        {
            string binary = String.Empty;
            string temp = String.Empty;

            int cnt = 0, rem = 0;

            for (; dec != 0; ++cnt)
            {
                rem = dec % 2;
                dec = dec / 2;
                temp += rem;
            }

            for (; temp.Length <= 7;)
            {
                temp += "0";
            }

            for (int i = temp.Length - 1; i >= 0; --i)
            {
                binary += temp[i];
            }

            return binary;
        }

        private string GetBase64(string bin)
        {
            string base64 = String.Empty;
            int dec = 0;

            for (int i = 0, j = (bin.Length - 1); i < bin.Length; ++i, --j)
            {
                dec += Convert.ToInt32(bin[j].ToString()) * Convert.ToInt32(Math.Pow(2, i));
            }

            switch (dec)
            {
                case 0:
                    base64 = "A";
                    break;
                case 1:
                    base64 = "B";
                    break;
                case 2:
                    base64 = "C";
                    break;
                case 3:
                    base64 = "D";
                    break;
                case 4:
                    base64 = "E";
                    break;
                case 5:
                    base64 = "F";
                    break;
                case 6:
                    base64 = "G";
                    break;
                case 7:
                    base64 = "H";
                    break;
                case 8:
                    base64 = "I";
                    break;
                case 9:
                    base64 = "J";
                    break;
                case 10:
                    base64 = "K";
                    break;
                case 11:
                    base64 = "L";
                    break;
                case 12:
                    base64 = "M";
                    break;
                case 13:
                    base64 = "N";
                    break;
                case 14:
                    base64 = "0";
                    break;
                case 15:
                    base64 = "P";
                    break;
                case 16:
                    base64 = "Q";
                    break;
                case 17:
                    base64 = "R";
                    break;
                case 18:
                    base64 = "S";
                    break;
                case 19:
                    base64 = "T";
                    break;
                case 20:
                    base64 = "U";
                    break;
                case 21:
                    base64 = "V";
                    break;
                case 22:
                    base64 = "W";
                    break;
                case 23:
                    base64 = "X";
                    break;
                case 24:
                    base64 = "Y";
                    break;
                case 25:
                    base64 = "Z";
                    break;
                case 26:
                    base64 = "a";
                    break;
                case 27:
                    base64 = "b";
                    break;
                case 28:
                    base64 = "c";
                    break;
                case 29:
                    base64 = "d";
                    break;
                case 30:
                    base64 = "e";
                    break;
                case 31:
                    base64 = "f";
                    break;
                case 32:
                    base64 = "g";
                    break;
                case 33:
                    base64 = "h";
                    break;
                case 34:
                    base64 = "i";
                    break;
                case 35:
                    base64 = "j";
                    break;
                case 36:
                    base64 = "k";
                    break;
                case 37:
                    base64 = "l";
                    break;
                case 38:
                    base64 = "m";
                    break;
                case 39:
                    base64 = "n";
                    break;
                case 40:
                    base64 = "o";
                    break;
                case 41:
                    base64 = "p";
                    break;
                case 42:
                    base64 = "q";
                    break;
                case 43:
                    base64 = "r";
                    break;
                case 44:
                    base64 = "s";
                    break;
                case 45:
                    base64 = "t";
                    break;
                case 46:
                    base64 = "u";
                    break;
                case 47:
                    base64 = "v";
                    break;
                case 48:
                    base64 = "w";
                    break;
                case 49:
                    base64 = "x";
                    break;
                case 50:
                    base64 = "y";
                    break;
                case 51:
                    base64 = "z";
                    break;
                case 52:
                    base64 = "0";
                    break;
                case 53:
                    base64 = "1";
                    break;
                case 54:
                    base64 = "2";
                    break;
                case 55:
                    base64 = "3";
                    break;
                case 56:
                    base64 = "4";
                    break;
                case 57:
                    base64 = "5";
                    break;
                case 58:
                    base64 = "6";
                    break;
                case 59:
                    base64 = "7";
                    break;
                case 60:
                    base64 = "8";
                    break;
                case 61:
                    base64 = "9";
                    break;
                case 62:
                    base64 = "+";
                    break;
                case 63:
                    base64 = "/";
                    break;
            }
            return base64;
        }
    }
}
