using System;
using System.Linq;

namespace Katas.Solutions.CodeFights
{
    public class Like0Hn0
    {
        bool Solve(int[][] g)
        {
            Func<int,bool> n = t => t != 0;
    
            int i=0,j=0;
            for(; i < g.Length; i++){
                for(; j < g.Length; j++){
                    var x = g[i][j];
            
                    if(x == 0) 
                        continue;
            
                    if(x != g[i].Skip(j + 1).TakeWhile(n).Count()
                       + g[i].Take(j).Reverse().TakeWhile(n).Count()
                       + g.Select(row => row[j]).Take(i).Reverse().TakeWhile(n).Count()
                       + g.Select(row => row[j]).Skip(i + 1).TakeWhile(n).Count())
                        return false;
                }
            }
            return true;   
        }
    }
}