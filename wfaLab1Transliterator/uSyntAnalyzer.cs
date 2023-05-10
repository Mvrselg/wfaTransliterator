using System;
using System.Collections.Generic;
using System.Text;
using nsLex;
using System.Windows.Forms;
using nsLexMainForm;
using nsHashTables;

namespace nsSynt
{
    class uSyntAnalyzer
    {
        const int word = 0;
        const int number = 0;
        const int reserved = 0;
        public TreeNode[] treeNodes = new TreeNode[1024];
        int i = 1;

        private String[] strFSource;
        private String[] strFMessage;
        public String[] strPSource { set { strFSource = value; } get { return strFSource; } }
        public String[] strPMessage { set { strFMessage = value; } get { return strFMessage; } }
        public CLex Lex = new CLex();

        public CHashTableList htl = new CHashTableList(3);
        int Count = 1;

        public List<string> listTable = new List<string>();
        int intVLexicalCode = 0;
        public uSyntAnalyzer()
        {
            treeNodes[0] = new TreeNode("S");
        }



        public void S()
        {
            if (i > 0)
            {
                treeNodes[i] = new TreeNode("S");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
            }
            i++;
            A();
            if (Lex.enumPToken == TToken.lxmdt)
            {
                treeNodes[i] = new TreeNode(":");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                Lex.NextToken();
                B();
            }
            throw new Exception("Ожидается :");

        }
        public void A()
        {
            if (i > 0)
            {
                treeNodes[i] = new TreeNode("A");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
            }
            i++;
            if (Lex.enumPToken == TToken.lxmIdentifier)
            {
                treeNodes[i] = new TreeNode(Lex.strPLexicalUnit.ToString());
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                htl.AddLexicalUnit(Lex.strPLexicalUnit, word, ref intVLexicalCode);
            }
                Lex.NextToken();
        }
        public void B()
        {
            if (i > 0)
            {
                treeNodes[i] = new TreeNode("B");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
            }
            i++;
            C();
            //Lex.NextToken();
            if (Lex.enumPToken == TToken.lxmtz)
            {
                treeNodes[i] = new TreeNode(";");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                F();
                //Lex.NextToken();
            }
            Lex.NextToken();
            throw new Exception("Ожидается ;");
        }
        public void F()
        {
            if (i > 0)
            {
                treeNodes[i] = new TreeNode("F");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
            }
            i++;
            if (Lex.enumPToken == TToken.lxmtz)
            {
                treeNodes[i] = new TreeNode(";");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                
                C();
                Lex.NextToken();
                if (Lex.enumPToken == TToken.lxmtz)
                {
                    treeNodes[i] = new TreeNode(";");
                    treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                    F();
                }
            }
        }

        public void C()
        {
            if (i > 0)
            {
                treeNodes[i] = new TreeNode("C");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
            }
            i++;
            Lex.NextToken();
            D();
            Lex.NextToken();
            {
                if (Lex.enumPToken == TToken.lxmComma)
                {
                    treeNodes[i] = new TreeNode(",");
                    treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                    G();
                    Lex.NextToken();
                }
                
                //throw new Exception("Ожидается ,");
            }
        }
        public void G()
        {
            if (i > 0)
            {
                treeNodes[i] = new TreeNode("G");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
            }
            i++;
            if (Lex.enumPToken == TToken.lxmComma)
            {
                treeNodes[i] = new TreeNode(",");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                Lex.NextToken();
                D();
                if (Lex.enumPToken == TToken.lxmComma)
                {
                    treeNodes[i] = new TreeNode(",");
                    treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                    G();
                }
                
            }
            //throw new Exception("Ожидается ,");
        }
        public void D()
        {
            if (i > 0)
            {
                treeNodes[i] = new TreeNode("D");
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
            }
            i++;
            Lex.NextToken();

            if (Lex.enumPToken == TToken.lxmNumber)
            {
                    treeNodes[i] = new TreeNode(Lex.strPLexicalUnit.ToString());
                    treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                    htl.AddLexicalUnit(Lex.strPLexicalUnit, number, ref intVLexicalCode);
                //throw new Exception("Конец слова, текст верный. ");
            }
            
            //throw new Exception("Конец слова, текст верный. ");

            //Lex.NextToken();
            else if (Lex.enumPToken == TToken.lxmIdentifier)
            {
                treeNodes[i] = new TreeNode(Lex.strPLexicalUnit.ToString());
                treeNodes[i - 1].Nodes.Add(treeNodes[i]);
                htl.AddLexicalUnit(Lex.strPLexicalUnit, word, ref intVLexicalCode);
            }
                //throw new Exception("Конец слова, текст верный. ");
            //Lex.NextToken();
        }
    }
}
