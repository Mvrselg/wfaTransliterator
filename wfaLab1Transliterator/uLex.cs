using System;
namespace nsLex
{
    public enum TState { Start, Continue, Finish, stMiddle, stExorbitant };
    public enum TCharType { Letter, Digit, EndRow, EndText, Space, ReservedSymbol, Unknown };
    public enum TToken
    {
        lxmIdentifier, lxmNumber, lxmUnknown, lxmEmpty, lxmLeftParenth, lxmRightParenth, lxmIs, lxmDot, lxmComma, lxmText, lxmtz, lxmdt, lxmr, lxmrs, lxmls
    };
    public struct CLiteral
    {
        public char chrFSelection;
        public TCharType enumFSelectionCharType;
    }
    public class CSourceCode
    {
        private String[] strFSource;  // указатель на массив строк
        private TState enumFState;
        private int intFSourceRowSelection;
        public int intFSourceColSelection;
        public String[] strPSource { set { strFSource = value; } get { return strFSource; } }

        public TState enumPState { set { enumFState = value; } get { return enumFState; } }
        public int intPSourceRowSelection { get { return intFSourceRowSelection; } }
        public int intPSourceColSelection { get { return intFSourceColSelection; } }
        public CSourceCode()
        {
            intFSourceRowSelection = 0;
            intFSourceColSelection = -1;
        }
        CLiteral GetSymbol()
        {
            CLiteral Literal;
            intFSourceColSelection++;
            if (intFSourceColSelection > strPSource[intFSourceRowSelection].Length - 1)
            {
                intFSourceRowSelection++;
                if (intFSourceRowSelection <= strFSource.Length - 1)
                {
                    intFSourceColSelection = -1;
                    Literal.chrFSelection = '\0';
                    Literal.enumFSelectionCharType = TCharType.EndRow;
                    enumFState = TState.stMiddle;
                    return Literal;
                }
                else
                {
                    Literal.chrFSelection = '\0';
                    Literal.enumFSelectionCharType = TCharType.EndText;
                    enumFState = TState.stExorbitant;
                    return Literal;
                }
            }
            else
            {
                Literal.chrFSelection = strFSource[intFSourceRowSelection][intFSourceColSelection];
                Literal.enumFSelectionCharType = TCharType.Unknown;
                enumFState = TState.stMiddle;
                return Literal;
            }
        }
    }

    public class CLex //: CSourceCode
    {
        private String[] strFSource;  // указатель на массив строк
        private String[] strFMessage;  // указатель на массив строк
        public TCharType enumFSelectionCharType;
        public char chrFSelection;
        private TState enumFState;
        private int intFSourceRowSelection;
        private int intFSourceColSelection;
        private String strFLexicalUnit;
        private TToken enumFToken;
        public String[] strPSource { set { strFSource = value; } get { return strFSource; } }
        public String[] strPMessage { set { strFMessage = value; } get { return strFMessage; } }
        public TState enumPState { set { enumFState = value; } get { return enumFState; } }
        public String strPLexicalUnit { set { strFLexicalUnit = value; } get { return strFLexicalUnit; } }
        public TToken enumPToken { set { enumFToken = value; } get { return enumFToken; } }
        public int intPSourceRowSelection { get { return intFSourceRowSelection; } set { intFSourceRowSelection = value; } }
        public int intPSourceColSelection { get { return intFSourceColSelection; } set { intFSourceColSelection = value; } }

        private CLiteral Literal;
        //public String[] strPMessage { set { strFMessage = value; } get { return strFMessage; } }
        public void GetSymbol() //метод класса лексический анализатор
        {
            intFSourceColSelection++; // продвигаем номер колонки
            if (intFSourceColSelection > strFSource[intFSourceRowSelection].Length - 1)
            {
                intFSourceRowSelection++;
                if (intFSourceRowSelection <= strFSource.Length - 1)
                {
                    intFSourceColSelection = -1;
                    chrFSelection = '\0';
                    enumFSelectionCharType = TCharType.EndRow;
                    enumFState = TState.Continue;
                }
                else
                {
                    chrFSelection = '\0';
                    enumFSelectionCharType = TCharType.EndText;
                    enumFState = TState.Finish;

                }
            }
            else
            {
                chrFSelection = strFSource[intFSourceRowSelection][intFSourceColSelection]; //классификация прочитанной литеры
                if (chrFSelection == ' ') enumFSelectionCharType = TCharType.Space;
                else if (chrFSelection >= 'a' && chrFSelection <= 'd') enumFSelectionCharType = TCharType.Letter;
                else if (chrFSelection == '0' || chrFSelection == '1') enumFSelectionCharType = TCharType.Digit;
                else if (chrFSelection == '/') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == '*') enumFSelectionCharType = TCharType.ReservedSymbol;

                else if (chrFSelection == '(' || chrFSelection == ')' || chrFSelection == ';' || chrFSelection == ':' || chrFSelection == ',' || chrFSelection == '.') enumFSelectionCharType = TCharType.ReservedSymbol;
                else throw new System.Exception("Cимвол вне алфавита");
                enumFState = TState.Continue;
            }
        }
        private void TakeSymbol()
        {
            char[] c = { chrFSelection };
            String s = new string(c);
            strFLexicalUnit += s;
            GetSymbol();
        }
        public void NextToken()
        {
            strFLexicalUnit = "";
            if (enumFState == TState.Start)
            {
                intFSourceRowSelection = 0;
                intFSourceColSelection = -1;
                GetSymbol();
            }
            while (enumFSelectionCharType == TCharType.Space || enumFSelectionCharType == TCharType.EndRow)
            {
                GetSymbol();
            }
            if (chrFSelection == '/')
            {
                GetSymbol();
                if (chrFSelection == '/')
                    while (enumFSelectionCharType != TCharType.EndRow)
                    {
                        GetSymbol();
                    }
                GetSymbol();
            }
            //Вариант 1
            switch (enumFSelectionCharType)
            {
                case TCharType.Letter:
                    {
                    //         a    b    c    d
                    //   A   |BFin|    |    |    |
                    //   B   |    |CFin|    |    |
                    //   C   |    |    |DFin|    |
                    //  DFin |    |    |    |Fin |

                    A:
                        {
                            if (chrFSelection == 'a')
                            {
                                TakeSymbol();
                                goto BFin;
                            }
                            else throw new Exception("Слово должно быть в алфавитном порядке");
                        }
                    BFin:
                        {
                            if (chrFSelection == 'a' || chrFSelection == 'b')
                            {
                                TakeSymbol();
                                goto CFin;
                            }
                            else throw new Exception("Слово должно быть в алфавитном порядке");
                        }
                    CFin:
                        {
                            if (chrFSelection == 'a' || chrFSelection == 'b' || chrFSelection == 'c')
                            {
                                TakeSymbol();
                                goto DFin;
                            }

                            else throw new Exception("Слово должно быть в алфавитном порядке");
                        }
                    DFin:
                        {
                            if (chrFSelection == 'a' || chrFSelection == 'b' || chrFSelection == 'c' || chrFSelection == 'd')
                            {
                                TakeSymbol();
                                goto DFin;
                            }
                            else
                            {
                                enumFToken = TToken.lxmIdentifier;
                                return;
                            }
                        }
                    }
                    if (chrFSelection == '/')
                    {
                        GetSymbol();
                        if (chrFSelection == '/')
                        {
                            while (enumFSelectionCharType != TCharType.EndRow)
                            {
                                GetSymbol();
                            }
                        }

                        GetSymbol();
                    }

                case TCharType.Digit:
                    {
                    //           0     1  
                    //    A   |  BD |     | 
                    //   BD   |  CF |     | 
                    //   CF   |  A  |FinG | 
                    //   FinG |  K  |     | 
                    //    K   |     |  M  | 
                    //    M   | FinG|     |
                    A:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto BD;
                        }
                        else throw new Exception("Ожидался 0");
                        BD:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto CF;
                        }
                        else throw new Exception("Ожидался 0");
                        CF:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto A;
                        }
                        else if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto FinG;
                        }
                        else throw new Exception("Ожидался 0 или 1");
                        FinG:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto K;
                        }
                        else if (enumFSelectionCharType != TCharType.Digit) { enumFToken = TToken.lxmNumber; return; }
                        else throw new Exception("Ожидался 0");
                        K:
                        if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto M;
                        }
                        else throw new Exception("Ожидался 1");
                        M:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto FinG;
                        }
                        else throw new Exception("Ожидался 0");
                    }
                case TCharType.ReservedSymbol:
                    {
                        if (chrFSelection == '/')
                        {
                            GetSymbol();
                            if (chrFSelection == '/')
                            {
                                while (enumFSelectionCharType != TCharType.EndRow)
                                    GetSymbol();
                            }
                            GetSymbol();
                        }
                        if (chrFSelection == '(')
                        {
                            enumFToken = TToken.lxmLeftParenth;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ')')
                        {
                            enumFToken = TToken.lxmRightParenth;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == '[')
                        {
                            enumFToken = TToken.lxmls;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ']')
                        {
                            enumFToken = TToken.lxmrs;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ',')
                        {
                            enumFToken = TToken.lxmComma;
                            TakeSymbol();
                            return;
                        }
                        if (chrFSelection == ':')
                        {
                            enumFToken = TToken.lxmdt;
                            TakeSymbol();
                            return;
                        }
                        if (chrFSelection == '=')
                        {
                            enumFToken = TToken.lxmr;
                            GetSymbol();
                            return;
                        }
                        if (chrFSelection == ';')
                        {
                            enumFToken = TToken.lxmtz;
                            TakeSymbol();
                            return;
                        }
                        break;
                    }
                case TCharType.EndText:
                    {
                        enumFToken = TToken.lxmEmpty;
                        break;
                    }
            }
        }

        CLiteral NextLiteral()
        {
            GetSymbol();
            if (Literal.enumFSelectionCharType == TCharType.Unknown)
                if (Literal.chrFSelection == ' ') Literal.enumFSelectionCharType = TCharType.Space;
                else if (Literal.chrFSelection >= 'a' && Literal.chrFSelection <= 'd') Literal.enumFSelectionCharType = TCharType.Letter;
                else if (Literal.chrFSelection == '0' || Literal.chrFSelection == '1') Literal.enumFSelectionCharType = TCharType.Digit;
                else if (Literal.chrFSelection == '<') Literal.enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (Literal.chrFSelection == '>') Literal.enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (Literal.chrFSelection == '|') Literal.enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (Literal.chrFSelection == ' ') Literal.enumFSelectionCharType = TCharType.ReservedSymbol;
                else throw new System.Exception(Literal.chrFSelection.ToString() + " Cимвол вне алфавита");
            return Literal;

        }
    }
}
