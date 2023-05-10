using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsSynt;
using nsLex;
using nsHashTables;

namespace nsLexMainForm
{
    public partial class Form1 : Form
    {
        public CHashTableList htl = new CHashTableList(3);
        public Form1()
        {
            InitializeComponent();
            tbFSource.AppendText("abcd:001;aaaa,aabb" + "\r\n");
            int n = tbFSource.Lines.Length;// длина строки
    }
        public void TablesToMemo(object sender, System.EventArgs e)
        {
            List<string> listTable = new List<string>();

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            htl.TableToStringList(0, listTable);
            for (int i = 0; i < listTable.Count; i++)
                listBox1.Items.Add(listTable[i]);
            listTable.Clear();

            htl.TableToStringList(1, listTable);
            for (int i = 0; i < listTable.Count; i++)
                listBox2.Items.Add(listTable[i]);
            listTable.Clear();

            htl.TableToStringList(2, listTable);
            for (int i = 0; i < listTable.Count; i++)
                listBox3.Items.Add(listTable[i]);
            listTable.Clear();
        }

        private void btnFStart_Click(object sender, EventArgs e)
        {
            tbFMessage.Clear();
            uSyntAnalyzer Synt = new uSyntAnalyzer();
            Synt.Lex.strPSource = tbFSource.Lines;
            Synt.Lex.strPMessage = tbFMessage.Lines;
            Synt.Lex.enumPState = TState.Start;
            try
            {
                Synt.Lex.NextToken();
                Synt.S();
                throw new Exception("Текст верный");
            }
            catch (Exception exc)
            {
                tbFMessage.Text += exc.Message;
                tbFSource.Select();
                tbFSource.SelectionStart = 0;
                int n = 0;
                for (int i = 0; i < Synt.Lex.intPSourceRowSelection; i++) n += tbFSource.Lines[i].Length + 2;
                n += Synt.Lex.intPSourceColSelection;
                tbFSource.SelectionLength = n;
            }
            SyntTree.Nodes.Clear();
            SyntTree.Nodes.Add(Synt.treeNodes[1]);
        }
        private void tbfSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLex Lex = new CLex();
            Lex.strPSource = tbFSource.Lines;
            Lex.strPMessage = tbFMessage.Lines;
            Lex.intPSourceColSelection = 0;
            Lex.intPSourceRowSelection = 0;
            tbFMessage.Text = "";
            try
            {
                while (Lex.enumPState != TState.Finish)
                {
                    Lex.NextToken();
                    string s1 = "", s = "";
                    switch (Lex.enumPToken)
                    {
                        case TToken.lxmIdentifier:
                            {
                                s1 = "id " + Lex.strPLexicalUnit; int b = 0;
                                if (htl.AddLexicalUnit(Lex.strPLexicalUnit, 0, ref b))
                                {
                                    TablesToMemo(this, e);
                                }
                                break;
                            }
                        case TToken.lxmNumber:
                            {
                                s1 = "num " + Lex.strPLexicalUnit; int b = 0;
                                if (htl.AddLexicalUnit(Lex.strPLexicalUnit, 1, ref b))
                                {
                                    TablesToMemo(this, e);
                                }
                                break;
                            }
                        case TToken.lxmdt:
                            {
                                s1 = "spec " + Lex.strPLexicalUnit; int b = 0;
                                if (htl.AddLexicalUnit(Lex.strPLexicalUnit, 2, ref b))
                                {
                                    TablesToMemo(this, e);
                                }
                                break;
                            }
                        case TToken.lxmtz:
                            {
                                s1 = "spec " + Lex.strPLexicalUnit; int b = 0;
                                if (htl.AddLexicalUnit(Lex.strPLexicalUnit, 2, ref b))
                                {
                                    TablesToMemo(this, e);
                                }
                                break;
                            }
                        case TToken.lxmComma:
                            {
                                s1 = "spec " + Lex.strPLexicalUnit; int b = 0;
                                if (htl.AddLexicalUnit(Lex.strPLexicalUnit, 2, ref b))
                                {
                                    TablesToMemo(this, e);
                                }
                                break;
                            }

                    }
                    String m = "(" + s + "" + s1 + " )";
                    tbFMessage.Text += m;
                }
            }
            catch (Exception exc)
            {
                tbFMessage.Text += exc.Message;
                tbFSource.Select();
                tbFSource.SelectionStart = 0;
                int n = 0;
                for (int i = 0; i < Lex.intPSourceRowSelection; i++) n += tbFSource.Lines[i].Length + 2;
                n += Lex.intPSourceColSelection;
                tbFSource.SelectionLength = n;
            }
        }    

  
    private void but_search_Click(object sender, EventArgs e)
        {
            CLex Lex = new CLex();
            Lex.strPSource = tbFSource.Lines;
            Lex.strPMessage = tbFMessage.Lines;
            tbFMessage.Text = "";
            int b = 0;
            byte check;
            int find = 0;
            string s1 = "";
            while (Lex.enumPState != TState.Finish)
            {
                Lex.NextToken();
                s1 = Lex.strPLexicalUnit;
                for (check = 0; check < 3; check++)
                {
                    if (htl.SearchLexicalUnit(Lex.strPLexicalUnit, check, ref b))
                    {
                        tbFMessage.Text += s1 + " ";
                        find++;
                    }

                }
                if (find == 0)
                {
                    tbFMessage.Text = "Такого символа нет";
                }
            }
        }

        private void but_delete_Click(object sender, EventArgs e)
        {
            CLex Lex = new CLex();
            Lex.strPSource = tbFSource.Lines;
            Lex.strPMessage = tbFMessage.Lines;
            tbFMessage.Text = "";
            byte check;
            int b = 0;
            int find = 0;
            while (Lex.enumPState != TState.Finish)
            {
                Lex.NextToken();
                for (check = 0; check < 3; check++)
                {
                    if (htl.SearchLexicalUnit(Lex.strPLexicalUnit, check, ref b))
                        find++;
                    htl.DeleteLexicalUnit(Lex.strPLexicalUnit, check);
                    TablesToMemo(this, e);
                }
                if (find == 0)
                {
                    tbFMessage.Text = "Такого символа нет";
                }
            }
        }
    }
}