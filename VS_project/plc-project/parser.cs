
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;



namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =  0, // (EOF)
        SYMBOL_ERROR              =  1, // (Error)
        SYMBOL_WHITESPACE         =  2, // Whitespace
        SYMBOL_MINUS              =  3, // '-'
        SYMBOL_MINUSMINUS         =  4, // '--'
        SYMBOL_EXCLAM             =  5, // '!'
        SYMBOL_EXCLAMEQ           =  6, // '!='
        SYMBOL_PERCENT            =  7, // '%'
        SYMBOL_LPAREN             =  8, // '('
        SYMBOL_RPAREN             =  9, // ')'
        SYMBOL_TIMES              = 10, // '*'
        SYMBOL_COMMA              = 11, // ','
        SYMBOL_DIV                = 12, // '/'
        SYMBOL_COLON              = 13, // ':'
        SYMBOL_SEMI               = 14, // ';'
        SYMBOL_LBRACE             = 15, // '{'
        SYMBOL_RBRACE             = 16, // '}'
        SYMBOL_PLUS               = 17, // '+'
        SYMBOL_PLUSPLUS           = 18, // '++'
        SYMBOL_LT                 = 19, // '<'
        SYMBOL_LTEQ               = 20, // '<='
        SYMBOL_EQ                 = 21, // '='
        SYMBOL_EQEQ               = 22, // '=='
        SYMBOL_GT                 = 23, // '>'
        SYMBOL_GTEQ               = 24, // '>='
        SYMBOL_AS                 = 25, // as
        SYMBOL_BOOL               = 26, // bool
        SYMBOL_BUILD              = 27, // build
        SYMBOL_CASE               = 28, // case
        SYMBOL_CLASS              = 29, // class
        SYMBOL_CONST              = 30, // const
        SYMBOL_DOUBLE             = 31, // double
        SYMBOL_FINISH             = 32, // finish
        SYMBOL_FLOAT              = 33, // float
        SYMBOL_FROM               = 34, // from
        SYMBOL_FUNC               = 35, // func
        SYMBOL_IDENT              = 36, // ident
        SYMBOL_INHERIT            = 37, // inherit
        SYMBOL_INT                = 38, // int
        SYMBOL_LONG               = 39, // long
        SYMBOL_LOOP               = 40, // loop
        SYMBOL_MATCH              = 41, // match
        SYMBOL_NEW                = 42, // new
        SYMBOL_NUMBER             = 43, // number
        SYMBOL_OPPS               = 44, // opps
        SYMBOL_OTHERWISE          = 45, // otherwise
        SYMBOL_PERFOM             = 46, // perfom
        SYMBOL_PERFORM            = 47, // perform
        SYMBOL_PRIVATE            = 48, // private
        SYMBOL_PROTECTED          = 49, // protected
        SYMBOL_PUBLIC             = 50, // public
        SYMBOL_PW                 = 51, // pw
        SYMBOL_STEPPING           = 52, // stepping
        SYMBOL_STOP               = 53, // stop
        SYMBOL_STRING             = 54, // string
        SYMBOL_TO                 = 55, // to
        SYMBOL_UNTILL             = 56, // untill
        SYMBOL_VOID               = 57, // void
        SYMBOL_ACCESS_LEVEL       = 58, // <access_level>
        SYMBOL_ASLONGAS_STMT      = 59, // <as long as_stmt>
        SYMBOL_ASSIGN             = 60, // <assign>
        SYMBOL_CASE2              = 61, // <case>
        SYMBOL_CASES_LIST         = 62, // <cases_list>
        SYMBOL_CLASS_DEF          = 63, // <class_def>
        SYMBOL_CLASS_NAME         = 64, // <class_name>
        SYMBOL_COND               = 65, // <cond>
        SYMBOL_CONSTANT           = 66, // <constant>
        SYMBOL_DATA_TYPE          = 67, // <data_type>
        SYMBOL_EXPONEN            = 68, // <exponen>
        SYMBOL_EXPR               = 69, // <expr>
        SYMBOL_FACTOR             = 70, // <factor>
        SYMBOL_INHER              = 71, // <inher>
        SYMBOL_LOOP_STMT          = 72, // <loop_stmt>
        SYMBOL_MATCH_STMT         = 73, // <match_stmt>
        SYMBOL_METHOD_CALL        = 74, // <method_call>
        SYMBOL_METHOD_DEF         = 75, // <method_def>
        SYMBOL_METHOD_NAME        = 76, // <method_name>
        SYMBOL_NUM                = 77, // <num>
        SYMBOL_OBJ_CREATION       = 78, // <obj_creation>
        SYMBOL_OBJ_NAME           = 79, // <obj_name>
        SYMBOL_OP                 = 80, // <op>
        SYMBOL_PARA               = 81, // <para>
        SYMBOL_PARAMS_LIST        = 82, // <params_list>
        SYMBOL_PERFORMUNTILL_STMT = 83, // <perform untill_stmt>
        SYMBOL_PROGRAME           = 84, // <programe>
        SYMBOL_RETURN_TYPE        = 85, // <return_type>
        SYMBOL_STEP               = 86, // <step>
        SYMBOL_STMT               = 87, // <stmt>
        SYMBOL_STMT_LIST          = 88, // <stmt_list>
        SYMBOL_TERM               = 89, // <term>
        SYMBOL_VAR                = 90  // <var>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAME_BUILD_FINISH                            =  0, // <programe> ::= build <stmt_list> finish
        RULE_STMT_LIST                                        =  1, // <stmt_list> ::= <stmt>
        RULE_STMT_LIST2                                       =  2, // <stmt_list> ::= <stmt> <stmt_list>
        RULE_STMT                                             =  3, // <stmt> ::= <assign>
        RULE_STMT2                                            =  4, // <stmt> ::= <as long as_stmt>
        RULE_STMT3                                            =  5, // <stmt> ::= <match_stmt>
        RULE_STMT4                                            =  6, // <stmt> ::= <loop_stmt>
        RULE_STMT5                                            =  7, // <stmt> ::= <perform untill_stmt>
        RULE_STMT6                                            =  8, // <stmt> ::= <method_def>
        RULE_STMT7                                            =  9, // <stmt> ::= <method_call>
        RULE_STMT8                                            = 10, // <stmt> ::= <class_def>
        RULE_STMT9                                            = 11, // <stmt> ::= <obj_creation>
        RULE_ASSIGN_EQ_SEMI                                   = 12, // <assign> ::= <var> '=' <expr> ';'
        RULE_VAR_IDENT                                        = 13, // <var> ::= ident
        RULE_CONSTANT_CONST                                   = 14, // <constant> ::= const <var>
        RULE_EXPR_PLUS                                        = 15, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                       = 16, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                             = 17, // <expr> ::= <term>
        RULE_TERM_TIMES                                       = 18, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                         = 19, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                     = 20, // <term> ::= <term> '%' <factor>
        RULE_TERM                                             = 21, // <term> ::= <factor>
        RULE_FACTOR_PW                                        = 22, // <factor> ::= <factor> pw <exponen>
        RULE_FACTOR                                           = 23, // <factor> ::= <exponen>
        RULE_EXPONEN_LPAREN_RPAREN                            = 24, // <exponen> ::= '(' <expr> ')'
        RULE_EXPONEN                                          = 25, // <exponen> ::= <var>
        RULE_EXPONEN2                                         = 26, // <exponen> ::= <num>
        RULE_NUM_NUMBER                                       = 27, // <num> ::= number
        RULE_ASLONGAS_STMT_AS_LONG_AS_PERFORM_COLON           = 28, // <as long as_stmt> ::= as long as <cond> perform ':' <stmt_list>
        RULE_ASLONGAS_STMT_AS_LONG_AS_PERFORM_COLON_OTHERWISE = 29, // <as long as_stmt> ::= as long as <cond> perform ':' <stmt_list> otherwise <stmt_list>
        RULE_COND                                             = 30, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                            = 31, // <op> ::= '<'
        RULE_OP_LTEQ                                          = 32, // <op> ::= '<='
        RULE_OP_GT                                            = 33, // <op> ::= '>'
        RULE_OP_GTEQ                                          = 34, // <op> ::= '>='
        RULE_OP_EQEQ                                          = 35, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                      = 36, // <op> ::= '!='
        RULE_MATCH_STMT_MATCH_LBRACE_RBRACE                   = 37, // <match_stmt> ::= match <expr> '{' <cases_list> '}'
        RULE_MATCH_STMT_MATCH_LBRACE_RBRACE_OPPS_EXCLAM       = 38, // <match_stmt> ::= match <expr> '{' <cases_list> '}' opps '!' <stmt_list>
        RULE_CASES_LIST                                       = 39, // <cases_list> ::= <case>
        RULE_CASES_LIST2                                      = 40, // <cases_list> ::= <case> <cases_list>
        RULE_CASE_CASE_COLON_STOP_COLON                       = 41, // <case> ::= case <expr> ':' <stmt_list> stop ':' <stmt_list>
        RULE_LOOP_STMT_LOOP_FROM_TO_STEPPING_PERFOM_COLON     = 42, // <loop_stmt> ::= loop from <data_type> <assign> to <cond> stepping <step> perfom ':' <stmt_list>
        RULE_DATA_TYPE_INT                                    = 43, // <data_type> ::= int
        RULE_DATA_TYPE_FLOAT                                  = 44, // <data_type> ::= float
        RULE_DATA_TYPE_DOUBLE                                 = 45, // <data_type> ::= double
        RULE_DATA_TYPE_STRING                                 = 46, // <data_type> ::= string
        RULE_DATA_TYPE_BOOL                                   = 47, // <data_type> ::= bool
        RULE_STEP_MINUSMINUS                                  = 48, // <step> ::= '--' <var>
        RULE_STEP_MINUSMINUS2                                 = 49, // <step> ::= <var> '--'
        RULE_STEP_PLUSPLUS                                    = 50, // <step> ::= '++' <var>
        RULE_STEP_PLUSPLUS2                                   = 51, // <step> ::= <var> '++'
        RULE_STEP                                             = 52, // <step> ::= <assign>
        RULE_PERFORMUNTILL_STMT_PERFORM_COLON_UNTILL          = 53, // <perform untill_stmt> ::= perform ':' <stmt_list> untill <cond>
        RULE_METHOD_DEF_FUNC_LPAREN_RPAREN_COLON              = 54, // <method_def> ::= func <access_level> <return_type> <method_name> '(' ')' ':' <stmt_list>
        RULE_METHOD_DEF_FUNC_LPAREN_RPAREN_COLON2             = 55, // <method_def> ::= func <access_level> <return_type> <method_name> '(' <params_list> ')' ':' <stmt_list>
        RULE_ACCESS_LEVEL_PUBLIC                              = 56, // <access_level> ::= public
        RULE_ACCESS_LEVEL_PROTECTED                           = 57, // <access_level> ::= protected
        RULE_ACCESS_LEVEL_PRIVATE                             = 58, // <access_level> ::= private
        RULE_RETURN_TYPE_VOID                                 = 59, // <return_type> ::= void
        RULE_RETURN_TYPE                                      = 60, // <return_type> ::= <data_type>
        RULE_METHOD_NAME_IDENT                                = 61, // <method_name> ::= ident
        RULE_PARAMS_LIST                                      = 62, // <params_list> ::= <para>
        RULE_PARAMS_LIST_COMMA                                = 63, // <params_list> ::= <para> ',' <params_list>
        RULE_PARA                                             = 64, // <para> ::= <data_type> <var>
        RULE_METHOD_CALL_LPAREN_RPAREN                        = 65, // <method_call> ::= <method_name> '(' ')'
        RULE_METHOD_CALL_LPAREN_RPAREN2                       = 66, // <method_call> ::= <method_name> '(' <params_list> ')'
        RULE_CLASS_DEF_CLASS_LBRACE_RBRACE                    = 67, // <class_def> ::= <access_level> class <class_name> '{' <stmt_list> '}'
        RULE_CLASS_DEF_CLASS_LBRACE_RBRACE2                   = 68, // <class_def> ::= <access_level> class <class_name> <inher> '{' <stmt_list> '}'
        RULE_CLASS_NAME_IDENT                                 = 69, // <class_name> ::= ident
        RULE_INHER_INHERIT                                    = 70, // <inher> ::= inherit <class_name>
        RULE_OBJ_CREATION_EQ_NEW_LPAREN_RPAREN                = 71, // <obj_creation> ::= <class_name> <obj_name> '=' new <class_name> '(' ')'
        RULE_OBJ_CREATION_EQ_NEW_LPAREN_RPAREN2               = 72, // <obj_creation> ::= <class_name> <obj_name> '=' new <class_name> '(' <params_list> ')'
        RULE_OBJ_NAME_IDENT                                   = 73  // <obj_name> ::= ident
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        public MyParser(string filename,ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AS :
                //as
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BUILD :
                //build
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONST :
                //const
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINISH :
                //finish
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM :
                //from
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //func
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENT :
                //ident
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INHERIT :
                //inherit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LONG :
                //long
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //loop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MATCH :
                //match
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEW :
                //new
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER :
                //number
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPPS :
                //opps
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERWISE :
                //otherwise
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERFOM :
                //perfom
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERFORM :
                //perform
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIVATE :
                //private
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROTECTED :
                //protected
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PUBLIC :
                //public
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PW :
                //pw
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEPPING :
                //stepping
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STOP :
                //stop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //to
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTILL :
                //untill
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESS_LEVEL :
                //<access_level>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASLONGAS_STMT :
                //<as long as_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE2 :
                //<case>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASES_LIST :
                //<cases_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_DEF :
                //<class_def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS_NAME :
                //<class_name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANT :
                //<constant>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA_TYPE :
                //<data_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPONEN :
                //<exponen>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INHER :
                //<inher>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP_STMT :
                //<loop_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MATCH_STMT :
                //<match_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_CALL :
                //<method_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_DEF :
                //<method_def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_NAME :
                //<method_name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //<num>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJ_CREATION :
                //<obj_creation>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJ_NAME :
                //<obj_name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARA :
                //<para>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS_LIST :
                //<params_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERFORMUNTILL_STMT :
                //<perform untill_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAME :
                //<programe>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_TYPE :
                //<return_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //<var>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAME_BUILD_FINISH :
                //<programe> ::= build <stmt_list> finish
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <stmt> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT :
                //<stmt> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT2 :
                //<stmt> ::= <as long as_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT3 :
                //<stmt> ::= <match_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT4 :
                //<stmt> ::= <loop_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT5 :
                //<stmt> ::= <perform untill_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT6 :
                //<stmt> ::= <method_def>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT7 :
                //<stmt> ::= <method_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT8 :
                //<stmt> ::= <class_def>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT9 :
                //<stmt> ::= <obj_creation>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI :
                //<assign> ::= <var> '=' <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR_IDENT :
                //<var> ::= ident
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANT_CONST :
                //<constant> ::= const <var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_PW :
                //<factor> ::= <factor> pw <exponen>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exponen>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPONEN_LPAREN_RPAREN :
                //<exponen> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPONEN :
                //<exponen> ::= <var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPONEN2 :
                //<exponen> ::= <num>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_NUMBER :
                //<num> ::= number
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASLONGAS_STMT_AS_LONG_AS_PERFORM_COLON :
                //<as long as_stmt> ::= as long as <cond> perform ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASLONGAS_STMT_AS_LONG_AS_PERFORM_COLON_OTHERWISE :
                //<as long as_stmt> ::= as long as <cond> perform ':' <stmt_list> otherwise <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MATCH_STMT_MATCH_LBRACE_RBRACE :
                //<match_stmt> ::= match <expr> '{' <cases_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MATCH_STMT_MATCH_LBRACE_RBRACE_OPPS_EXCLAM :
                //<match_stmt> ::= match <expr> '{' <cases_list> '}' opps '!' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASES_LIST :
                //<cases_list> ::= <case>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASES_LIST2 :
                //<cases_list> ::= <case> <cases_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_CASE_COLON_STOP_COLON :
                //<case> ::= case <expr> ':' <stmt_list> stop ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_STMT_LOOP_FROM_TO_STEPPING_PERFOM_COLON :
                //<loop_stmt> ::= loop from <data_type> <assign> to <cond> stepping <step> perfom ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_INT :
                //<data_type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_FLOAT :
                //<data_type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_DOUBLE :
                //<data_type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_STRING :
                //<data_type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_BOOL :
                //<data_type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <var> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <var> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PERFORMUNTILL_STMT_PERFORM_COLON_UNTILL :
                //<perform untill_stmt> ::= perform ':' <stmt_list> untill <cond>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_DEF_FUNC_LPAREN_RPAREN_COLON :
                //<method_def> ::= func <access_level> <return_type> <method_name> '(' ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_DEF_FUNC_LPAREN_RPAREN_COLON2 :
                //<method_def> ::= func <access_level> <return_type> <method_name> '(' <params_list> ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESS_LEVEL_PUBLIC :
                //<access_level> ::= public
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESS_LEVEL_PROTECTED :
                //<access_level> ::= protected
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESS_LEVEL_PRIVATE :
                //<access_level> ::= private
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_VOID :
                //<return_type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE :
                //<return_type> ::= <data_type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_NAME_IDENT :
                //<method_name> ::= ident
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS_LIST :
                //<params_list> ::= <para>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS_LIST_COMMA :
                //<params_list> ::= <para> ',' <params_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARA :
                //<para> ::= <data_type> <var>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_CALL_LPAREN_RPAREN :
                //<method_call> ::= <method_name> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_CALL_LPAREN_RPAREN2 :
                //<method_call> ::= <method_name> '(' <params_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_DEF_CLASS_LBRACE_RBRACE :
                //<class_def> ::= <access_level> class <class_name> '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_DEF_CLASS_LBRACE_RBRACE2 :
                //<class_def> ::= <access_level> class <class_name> <inher> '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_NAME_IDENT :
                //<class_name> ::= ident
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INHER_INHERIT :
                //<inher> ::= inherit <class_name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJ_CREATION_EQ_NEW_LPAREN_RPAREN :
                //<obj_creation> ::= <class_name> <obj_name> '=' new <class_name> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJ_CREATION_EQ_NEW_LPAREN_RPAREN2 :
                //<obj_creation> ::= <class_name> <obj_name> '=' new <class_name> '(' <params_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJ_NAME_IDENT :
                //<obj_name> ::= ident
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "  Parse error caused by token: '"+args.UnexpectedToken.ToString()+"  In line: "+args.UnexpectedToken .Location .LineNr ;

             lst .Items .Add (message);
            string m2 ="   ";
            lst.Items .Add (m2);    

            string m3 =  "Expected Token: " + args.ExpectedTokens.ToString();
            lst.Items.Add(m3);
            //todo: Report message to UI?
        }

    }
}
