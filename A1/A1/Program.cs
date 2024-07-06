using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace A1
{
    public class Program
    {
        static void Main(string[] args)
        {}

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TypeOfSize5
        {
            public int a;
            public char b;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TypeOfSize22
        {
            TypeOfSize5 c,d,e,f;
            public char a, b;
        }

        public struct TypeOfSize125
        {
            TypeOfSize22 a,b,c,d,e;
            TypeOfSize5 f,g,h;
        }

        public struct TypeOfSize1024
        {
            TypeOfSize125 a,b,c,d,e,f,g,h;
            TypeOfSize22 i;
            public char j,k;
        }

        public struct TypeOfSize32768
        {
            TypeOfSize1024 a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,z1,z2,z3,z4,z5,z6;
        }


        public struct TypeForMaxStackOfDepth10
        {
            TypeOfSize32768 a,b,c;
        }

        public struct TypeForMaxStackOfDepth100
        {
            TypeOfSize1024 a,b,c,d,e,f,g,h,i,j;
        }

        public struct TypeForMaxStackOfDepth1000
        {
            TypeOfSize125 a,b,c,d,e,f,g,h;
        }

        public struct TypeForMaxStackOfDepth3000
        {
            TypeOfSize22 a,b,c,d,e,f,g,h,i,j,k,l,m;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class TypeWithMemoryOnHeap
        {
            public double[] d;
            public void Allocate()
            {
                d = new double[500000];
            }
            public void DeAllocate()
            {
                d = null;
            }
        }


        public struct StructOrClass1
        {
            public int X;
        }

        public class StructOrClass2
        {
            public int X;
        }

        public class StructOrClass3
        {
            public StructOrClass2 X;
        }

        

        public static int GetObjectType(object o)
        {
            if (o is string)
                { return 0; }
            else if (o is int[])
                { return 1; }
            else if (o is int)
                { return 2; }
            else
                { return 100; }
        }

        public enum FutureHusbandType : int
        {
            HasBigNose = 0b0001,
            IsBald = 0b0010,
            IsShort = 0b0100,
        }
        public static bool IdealHusband(FutureHusbandType fht)
        {
            int f = Convert.ToInt32(fht);
            if (f == 0b0001)
            { return false; }
            else if (f == 2)
            { return false; }
            else if (f == 4)
            { return false; }
            else if (f == 7)
            { return false; }
            else
            { return true; }
        }
    }
}