using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace ZipChip
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstviewMain.ListViewItemSorter = lvwColumnSorter;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public List<String> importArray(string filename)
        {
            list.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); // Add to list.
                }
            }
            return list;
        }

        public string[] substrings(string s, int n)
        {
            string[] sr = new string[s.Length - n + 1];

            for (int i = 0; i < s.Length - n + 1; i++)
            {
                sr[i] = s.Substring(i, n);
            }

            return sr;
        }

        public int[] mValues(string parent, string child)
        {
            //bool almostDone = false;
            int[] n = new int[child.Length];

            double m = (parent.Length + (double) child.Length) /
                       10; //(parent.Split(' ').Length + child.Split(' ').Length) / 2;
            //MessageBox.Show(m.ToString());

            for (int i = child.Length - 1; i > 0; i--)
            {
                foreach (string s in substrings(child, i + 1))
                    if (parent.ToLower().Contains(s.ToLower()) && s.Length > n[i])
                    {
                        //MessageBox.Show(s.Length.ToString());
                        n[i] = s.Length;
                    }
            }


            string c = child;
            if (c.Length > 3)
                c = c.Substring(0, 3);
            double q = parent.ToLower().StartsWith(c) ? 1.85 : 1;

            //double d = m * ((double)(n * child.Length)) / 5; //parent.Length ?????
            //int j = Convert.ToInt32(q * (double) n / 3/*m*/);

            for (int i = 0; i < n.Length; i++)
                n[i] = Convert.ToInt32(n[i] * 0.66 * q / m);
            //int j = Convert.ToInt32(/*5 */ 0.66 * q * n / m);
            return n;

        }

        private ListViewColumnSorter lvwColumnSorter;

        List<string> list = new List<string>();
        private string[] zipList;
        private string[] zC;
        private string[] z;
        private string[] c;

        private string[] cS;

        private string[] zS;


        private void frmMain_Load(object sender, EventArgs e)
        {



            foreach (Process p in Process.GetProcesses())
                if (p.MainWindowTitle.Contains("ZipChip v1.50"))
                {
                    MessageBox.Show("Already running..", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetForegroundWindow(p.MainWindowHandle);
                    this.Close();
                }

            string[] cX =
            {
                "ANDORRA", "UNITED ARAB EMIRATES", "AFGHANISTAN", "ANTIGUA AND BARBUDA", "ANGUILLA", "ALBANIA",
                "ARMENIA", "NETHERLANDS ANTILLES", "ANGOLA", "ANTARCTICA", "ARGENTINA", "AMERICAN SAMOA", "AUSTRIA",
                "AUSTRALIA", "ARUBA", "AZERBAIJAN", "BOSNIA AND HERZEGOWINA", "BARBADOS", "BANGLADESH", "BELGIUM",
                "BURKINA FASO", "BULGARIA", "BAHRAIN", "BURUNDI", "BENIN", "BERMUDA", "BRUNEI DARUSSALAM", "BOLIVIA",
                "BRAZIL", "BAHAMAS", "BHUTAN", "BOUVET ISLAND", "BOTSWANA", "BELARUS", "BELIZE", "CANADA",
                "COCOS (KEELING) ISLANDS", "CONGO, THE DRC", "CENTRAL AFRICAN REPUBLIC", "CONGO", "SWITZERLAND",
                "COTE D'IVOIRE", "COOK ISLANDS", "CHILE", "CAMEROON", "CHINA", "COLOMBIA", "COSTA RICA", "CUBA",
                "CAPE VERDE", "CHRISTMAS ISLAND", "CYPRUS", "CZECH REPUBLIC", "GERMANY", "DJIBOUTI", "DENMARK",
                "DOMINICA", "DOMINICAN REPUBLIC", "ALGERIA", "ECUADOR", "ESTONIA", "EGYPT", "WESTERN SAHARA", "ERITREA",
                "SPAIN", "ETHIOPIA", "FINLAND", "FIJI", "FALKLAND ISLANDS (MALVINAS)",
                "MICRONESIA, FEDERATED STATES OF", "FAROE ISLANDS", "FRANCE", "FRANCE, METROPOLITAN", "GABON",
                "UNITED KINGDOM", "GRENADA", "GEORGIA", "FRENCH GUIANA", "GHANA", "GIBRALTAR", "GREENLAND", "GAMBIA",
                "GUINEA", "GUADELOUPE", "EQUATORIAL GUINEA", "GREECE", "SOUTH GEORGIA AND SOUTH S.S.", "GUATEMALA",
                "GUAM", "GUINEA-BISSAU", "GUYANA", "HONG KONG", "HEARD AND MC DONALD ISLANDS", "HONDURAS",
                "CROATIA (Hrvatska)", "HAITI", "HUNGARY", "INDONESIA", "IRELAND", "ISRAEL", "INDIA",
                "BRITISH INDIAN OCEAN TERRITORY", "IRAQ", "IRAN", "ICELAND", "ITALY", "JAMAICA",
                "JORDAN", "JAPAN", "KENYA", "KYRGYZSTAN", "CAMBODIA", "KIRIBATI", "COMOROS", "SAINT KITTS AND NEVIS",
                "KOREA, DPRO", "KOREA, REPUBLIC", "KUWAIT", "CAYMAN ISLANDS", "KAZAKHSTAN", "LAOS", "LEBANON",
                "SAINT LUCIA", "LIECHTENSTEIN", "SRI LANKA", "LIBERIA", "LESOTHO", "LITHUANIA", "LUXEMBOURG", "LATVIA",
                "LIBYAN ARAB JAMAHIRIYA", "MOROCCO", "MONACO", "MOLDOVA, REPUBLIC OF", "SINT MAARTEN", "MADAGASCAR",
                "MARSHALL ISLANDS", "MACEDONIA", "MALI", "MYANMAR (Burma)", "MONGOLIA", "MACAU",
                "NORTHERN MARIANA ISLANDS", "MARTINIQUE", "MAURITANIA", "MONTSERRAT", "MALTA", "MAURITIUS", "MALDIVES",
                "MALAWI", "MEXICO", "MALAYSIA", "MOZAMBIQUE", "NAMIBIA", "NEW CALEDONIA", "NIGER", "NORFOLK ISLAND",
                "NIGERIA", "NICARAGUA", "NETHERLANDS", "NORWAY", "NEPAL", "NAURU", "NIUE", "NEW ZEALAND", "OMAN",
                "PANAMA", "PERU", "FRENCH POLYNESIA", "PAPUA NEW GUINEA", "PHILIPPINES", "PAKISTAN", "POLAND",
                "ST. PIERRE AND MIQUELON", "PITCAIRN", "PUERTO RICO", "PORTUGAL", "PALAU", "PARAGUAY", "QATAR",
                "REUNION", "ROMANIA", "SERBIA", "RUSSIAN FEDERATION", "RWANDA", "SAUDI ARABIA", "SOLOMON ISLANDS",
                "SEYCHELLES", "SUDAN", "SWEDEN", "SINGAPORE", "ST. HELENA", "SLOVENIA",
                "SVALBARD AND JAN MAYEN ISLANDS", "SLOVAKIA", "SIERRA LEONE", "SAN MARINO", "SENEGAL",
                "SOMALIA", "SURINAME", "SAO TOME AND PRINCIPE", "EL SALVADOR", "SYRIAN ARAB REPUBLIC", "SWAZILAND",
                "TURKS AND CAICOS ISLANDS", "CHAD", "FRENCH SOUTHERN TERRITORIES", "TOGO", "THAILAND", "TAJIKISTAN",
                "TOKELAU", "TURKMENISTAN", "TUNISIA", "TONGA", "EAST TIMOR", "TURKEY", "TRINIDAD AND TOBAGO", "TUVALU",
                "TAIWAN, PROVINCE OF CHINA", "TANZANIA, UNITED REPUBLIC OF", "UKRAINE", "UGANDA", "U.S. MINOR ISLANDS",
                "UNITED STATES", "URUGUAY", "UZBEKISTAN", "HOLY SEE (VATICAN CITY STATE)",
                "SAINT VINCENT AND THE GRENADINES", "VENEZUELA", "VIRGIN ISLANDS (BRITISH)", "VIRGIN ISLANDS (U.S.)",
                "VIETNAM", "VANUATU", "WALLIS AND FUTUNA ISLANDS", "SAMOA", "YEMEN", "MAYOTTE",
                "Yugoslavia (Serb & Mont)", "SOUTH AFRICA", "ZAMBIA", "ZIMBABWE"
            };
            string[] zX =
            {
                "AD", "AE", "AF", "AG", "AI", "AL", "AM", "AN", "AO", "AQ", "AR", "AS", "AT", "AU", "AW", "AZ", "BA",
                "BB",
                "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BM", "BN", "BO", "BR", "BS", "BT", "BV", "BW", "BY", "BZ",
                "CA",
                "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM", "CN", "CO", "CR", "CU", "CV", "CX", "CY", "CZ",
                "DE",
                "DJ", "DK", "DM", "DO", "DZ", "EC", "EE", "EG", "EH", "ER", "ES", "ET", "FI", "FJ", "FK", "FM", "FO",
                "FR",
                "FX", "GA", "GB", "GD", "GE", "GF", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS", "GT", "GU",
                "GW",
                "GY", "HK", "HM", "HN", "HR", "HT", "HU", "ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT", "JM",
                "JO",
                "JP", "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK",
                "LR",
                "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD", "MF", "MG", "MH", "MK", "ML", "MM", "MN", "MO", "MP",
                "MQ",
                "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG", "NI", "NL", "NO",
                "NP",
                "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", "PN", "PR", "PT", "PW", "PY",
                "QA",
                "RE", "RO", "RS", "RU", "RW", "SA", "SB", "SC", "SD", "SE", "SG", "SH", "SI", "SJ", "SK", "SL", "SM",
                "SN",
                "SO", "SR", "ST", "SV", "SY", "SZ", "TC", "TD", "TF", "TG", "TH", "TJ", "TK", "TM", "TN", "TO", "TP",
                "TR",
                "TT", "TV", "TW", "TZ", "UA", "UG", "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", "VN", "VU",
                "WF",
                "WS", "YE", "YT", "YU", "ZA", "ZM", "ZW"
            };

            for (int i = 0; i < cX.Length; i++)
                cX[i] = Regex.Replace(cX[i], @"[^0-9a-zA-Z]+", " ");

            string root = Application.StartupPath + "\\zipCodes";
            try
            {
                zipList = Directory.GetFiles(root);
                for (int i = 0; i < zipList.Length; i++)
                {
                    if (zipList[i].StartsWith(root))
                        zipList[i] = zipList[i].Remove(0, root.Length);
                    if (zipList[i].Contains("\\"))
                        zipList[i] = zipList[i].Remove(zipList[i].IndexOf("\\"), 1);
                    if (zipList[i].Contains(".txt"))
                        zipList[i] = zipList[i].Remove(zipList[i].IndexOf(".txt"), 4);
                }
            }
            catch
            {
                MessageBox.Show("Data directory not found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            foreach (string s in zipList)
                comSt.Items.Add(s);


            //MessageBox.Show(comSt.Items[0].ToString());


            int counter = 0;
            for (int i = 0; i < zX.Length; i++)
            for (int j = 0; j < comSt.Items.Count; j++)
                if (comSt.Items[j].ToString() == zX[i])
                    counter++;


            cS = new string[counter];
            zS = new string[counter];
            for (int i = 0; i < zX.Length; i++)
            for (int j = 0; j < comSt.Items.Count; j++)
                if (comSt.Items[j].ToString() == zX[i])
                {
                    cS[j] = cX[i];
                    zS[j] = zX[i];
                }




            var source = new AutoCompleteStringCollection();



            source.AddRange(cS);


            cntrySrch.AutoCompleteCustomSource = source;
            cntrySrch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cntrySrch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            lstviewMain.FullRowSelect = true;
            //MessageBox.Show(string.Join("\r\n", zipList));
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
            else if (!Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsSeparator((e.KeyChar)))
            {
                e.Handled = true;
                zipchipTimeout.Stop();
                zipchipTimeout.Start();
            }
            else
            {
                zipchipTimeout.Stop();
                zipchipTimeout.Start();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstviewMain.Sort();
        }



        private bool busy = false;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString()+e.ToString());


            /*if (!mHc)
            {
                mHt = true;
                //MessageBox.Show(cntrySrch.Text);
                for (int i = 0; i < zS.Length; i++)
                    if (cS[i].ToLower() == cntrySrch.Text.ToLower() && comSt.Items.Contains(zS[i]))
                    {
                        comSt.Text = zS[i];
                        refresh();
                        mHt = false;
                        break;
                    }
            }*/
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!busy)
            {
                //mHc = true;
                busy = true;
                refresh();
                busy = false;
            }
        }

        private void refresh()
        {
            if (comSt.Text.Length == 2 && comSt.Items.Contains(comSt.Text.ToUpper()))
            {
                lstviewMain.Items.Clear();
                foreach (string s in comSt.Items)
                    if (s == comSt.Text)
                    {
                        txtCit.Enabled = true;
                        comSt.TabStop = false;
                        //txtCit.Focus();
                        zC = importArray(Application.StartupPath + "\\zipCodes\\" + s + ".txt").ToArray();

                        for (int i = 0; i < zC.Length; i++)
                            zC[i] = Regex.Replace(zC[i], @"\s+", " ");

                        //MessageBox.Show(zC[0]);
                        //Array.Sort(zC);
                        z = new string[zC.Length];
                        c = new string[zC.Length];
                        for (int i = 0; i < zC.Length; i++)
                        {
                            //MessageBox.Show(zC[i].Split('|')[0]);
                            z[i] = zC[i].Substring(0, zC[i].IndexOf(" ")); //zC[i].Split('\0')[0];
                            c[i] = zC[i].Remove(0, zC[i].IndexOf(" "));
                            c[i] = Regex.Replace(c[i], @"[^0-9a-zA-Z]+", " ");
                            //c[i] = zC[i].Split('\0')[1];
                            //c[i] = zC[i].Remove(zC[i].IndexOf(z[i]), z[i].Length + 1);
                            //MessageBox.Show(c[0]);
                            ListViewItem itm = new ListViewItem(z[i]);
                            itm.SubItems.Add(c[i]);
                            if (!z[i].StartsWith(comSt.Text))
                                itm.BackColor = Color.LimeGreen;
                            lstviewMain.Items.Add(itm);
                            //label3.Text = z[0];
                        }
                        //MessageBox.Show(cntrySrch.Text);
                        for (int i = 0; i < cS.Length; i++)
                            if (comSt.Text == zS[i] && cntrySrch.Text.ToLower() != cS[i].ToLower())
                            {
                                //MessageBox.Show(cntrySrch.Text);

                                //mHt = false;
                                cntrySrch.Text = cS[i];
                                //mHc = true;
                                break;
                            }
                        break;
                    }
            }
            else
            {
                //mHc = false;
                lstviewMain.Items.Clear();
                txtCit.Enabled = false;
                comSt.TabStop = true;
            }
        }

        private void txtCit_TextChanged(object sender, EventArgs e)
        {
            busy = true;
            //MessageBox.Show(txtCit.Text);
            lstviewMain.Items.Clear();
            if (txtCit.TextLength == 0)
                for (int i = 0; i < z.Length; i++)
                {
                    ListViewItem itm = new ListViewItem(z[i]);
                    itm.SubItems.Add(c[i]);
                    lstviewMain.Items.Add(itm);
                }
            else
            {
                //MessageBox.Show(txtCit.Text);
                //MessageBox.Show(string.Join(", ", zC));
                int[] q = new int[zC.Length];
                for (int i = 0; i < q.Length; i++)
                    q[i] = mValues(c[i], txtCit.Text).Sum();

                int max = q.Max();
                int[] mC = new int[max];

                //MessageBox.Show("1");

                for (int y = max; y > 0; y--)
                for (int x = 0; x < q.Length; x++)
                    if (q[x] == y)
                    {
                        //MessageBox.Show(q[x].ToString());
                        ListViewItem itm = new ListViewItem(z[x]);
                        itm.SubItems.Add(c[x]);
                        if (!z[x].StartsWith(comSt.Text))
                            itm.BackColor = Color.LimeGreen;
                        lstviewMain.Items.Add(itm);
                    }
            }
            busy = false;
        }

        private void txtCit_KeyDown(object sender, KeyEventArgs e)
        {
            zipchipTimeout.Stop();
            zipchipTimeout.Start();
            if (e.KeyCode.ToString() == "Escape")
            {
                e.SuppressKeyPress = true;
                cntrySrch.Focus();
            }
            else if (e.KeyCode.ToString() == "Return")
                e.SuppressKeyPress = true;
        }


        private void comSt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Escape")
            {
                e.SuppressKeyPress = true;
                cntrySrch.Focus();
            }
        }


        private void cntrySrch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsSeparator((e.KeyChar)))
            {
                e.Handled = true;
                zipchipTimeout.Stop();
                zipchipTimeout.Start();
            }
            else
            {
                zipchipTimeout.Stop();
                zipchipTimeout.Start();
            }
        }

        private void cntrySrch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return" && !busy)
            {
                busy = true;

                for (int i = 0; i < zS.Length; i++)
                    if (cS[i].ToLower() == cntrySrch.Text.ToLower() && comSt.Items.Contains(zS[i]))
                    {
                        comSt.Text = zS[i];
                        //if (txtCit.TextLength > 0)
                            refresh();
                        txtCit.Focus();
                        break;
                    }
                busy = false;
            }
            //MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode.ToString() == "Escape")
                this.Close();
        }


        private void comSt_DropDownClosed(object sender, EventArgs e)
        {
            //txtCit.Enabled = true;
            busy = true;
            refresh();
            busy = false;
            //MessageBox.Show(cS[0]);
            try
            {
                for (int i = 0; i < comSt.Items.Count; i++)
                    if (comSt.Text == comSt.Items[i].ToString())
                        txtCit.Focus();
                //MessageBox.Show("k");//
            }
            catch { }
        }

        private void zipchipTimeout_Tick(object sender, EventArgs e)
        {
            txtCit.SelectAll();
            cntrySrch.SelectAll();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!busy)
            {
                busy = true;
                //MessageBox.Show(zS[0]);

                for (int i = 0; i < zS.Length; i++)
                    if (cS[i].ToLower() == cntrySrch.Text.ToLower() && comSt.Items.Contains(zS[i]))
                    {
                        comSt.Text = zS[i];
                        //if (txtCit.TextLength > 0)
                            refresh();
                        txtCit.Focus();
                        break;
                    }
                busy = false;
            }
        }

        private void cntrySrch_TextChanged(object sender, EventArgs e)
        {
            for (int i=0; i<cS.Length;i++)
                if (cntrySrch.Text == cS[i])
                {
                    btnLoad.Enabled = true;
                    return;
                }
            btnLoad.Enabled = false;
        }

        private void cntrySrch_Enter(object sender, EventArgs e)
        {
            cntrySrch.SelectAll();
        }

        private void cntrySrch_MouseUp(object sender, MouseEventArgs e)
        {
            cntrySrch.SelectAll();
        }

        private void txtCit_Enter(object sender, EventArgs e)
        {
            txtCit.SelectAll();
        }

        private void txtCit_MouseUp(object sender, MouseEventArgs e)
        {
            txtCit.SelectAll();
        }

        private void lstviewMain_Leave(object sender, EventArgs e)
        {
            lstviewMain.SelectedItems.Clear();
        }
    }
}
