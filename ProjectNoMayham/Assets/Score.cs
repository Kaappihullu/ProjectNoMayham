using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Score
{

    private static int m_score = 0;

    public static void Calc(int delta)
    {
        m_score += delta;
    }

    public int Total
    {
        get
        {
            return m_score;
        }
    }


}
