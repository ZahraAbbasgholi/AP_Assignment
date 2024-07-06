using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace A2
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                    if (_Input.Length < 50)
                        return _Input;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {
                    if (value.Length < 50)
                        _Input = value;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    string test = null;
                    if (test.Length > 0)
                        Console.WriteLine("test");
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            try
            {
                int n = int.Parse(Input);
                if (n>11)
                {
                    string s = "99999999999999999";
                    int i = int.Parse(s);
                }
            }
            catch (OverflowException ofe)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {ofe.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            try
            {
                int n = int.Parse(Input);
                if (n < 11)
                {
                    string s = File.ReadAllText(@"..\text.txt");
                }
                else
                {
                    string ss = File.ReadAllText(@"..\test.txt");
                }
            }
            catch(FileNotFoundException fnfe)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {fnfe.GetType()}";
            }
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                int n = int.Parse(Input);
                var nums = new int[1]{1};
                int sum = 0;
                for (int i=1; i<=n; i++)
                {
                    sum += nums[i-1] + nums[i];
                }
            }
            catch (IndexOutOfRangeException ioore)
            {
                if (DoNotThrow == false)
                    throw;
                ErrorMsg = $"Caught exception {ioore.GetType()}";
            }
        }

        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                int n = int.Parse(Input);
                double[] d = new double[n];
            }
            catch (OutOfMemoryException oome)
            {
                if (DoNotThrow == false)
                    throw;
                ErrorMsg = $"Caught exception {oome.GetType()}";
            }
        }

        public void MultiExceptionMethod()
        {
            try
            {
                int n = int.Parse(Input);
                int[] m = new int[n];
                int sum = new int();
                for (int i=0; i<n; i++)
                {
                    sum += m[i-1] + m[i];
                }
            }
            catch (IndexOutOfRangeException ioore)
            {
                if (DoNotThrow == false)
                    throw;
                ErrorMsg = $"Caught exception {ioore.GetType()}";
            }
            catch (OutOfMemoryException oome)
            {
                if (DoNotThrow == false)
                    throw;
                ErrorMsg = $"Caught exception {oome.GetType()}";
            }
        }

        public static void ThrowIfOdd(int n)
        {
            try
            {
                if (n % 2 == 0){} 
                else
                {
                    throw (new InvalidDataException("Odd Number"));
                }   
            }
            catch(InvalidDataException ide)
            {
                throw ide;
            }
        }

        public string FinallyBlockStringOut;

        public void FinallyBlockMethod(string s)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter swr = new StringWriter(sb);
            try
            {
                swr.Write("InTryBlock:");
                if (s == null)
                {
                    swr.Write(":Object reference not set to an instance of an object.");
                    throw (new NullReferenceException());
                }
                else
                {
                    if (s.Length > 6)
                    {
                        swr.Write($"{s}:{s.Length}");
                    }
                    else
                    {
                        return;
                    }
                }
                swr.Write(":DoneWriting");
            }
            catch (NullReferenceException nre)
            {
                if (DoNotThrow == false)
                    throw;
                ErrorMsg = $"Caught exception {nre.GetType()}";
            }
            finally
            {
                swr.Write(":InFinallyBlock");
                swr.Dispose();
                FinallyBlockStringOut = sb.ToString();
            }
            FinallyBlockStringOut += ":EndOfMethod";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void NestedMethods()
        {
            MethodA();
        }

        public static void MethodA()
        {
            MethodB();
        }
        public static void MethodB()
        {
            MethodC();
        }

        public static void MethodC()
        {
            MethodD();
        }

        public static void MethodD()
        {
            throw (new NotImplementedException());
        }

        static void Main(string[] args)
        {}
    }
}
