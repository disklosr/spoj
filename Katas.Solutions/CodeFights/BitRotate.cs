using System;
using System.Collections;

namespace Katas.Solutions.CodeFights
{
    public class BitRotate
    {
        int Solve(int n, int r) {
            if(r == 0)
                return n;
    
            var source = new BitArray(new[] { n });
            var target = new BitArray(32);
    
    
            var rotateBy = Math.Abs(r) % 31;
    

            if (r > 0)
            {
                for (var i = 0; i < 31; i++)
                {
                    target.Set(i, source.Get((i - rotateBy + 31) % 31));
                }
            }
        
            else
            {
                for (var i = 0; i < 31; i++)
                {
                    target.Set(i, source.Get((i + rotateBy) % 31));
                }
            }

            var array = new int[1];
            target.CopyTo(array, 0);
            return array[0];
        }
        
        
    }
}