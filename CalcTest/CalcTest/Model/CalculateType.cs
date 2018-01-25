﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTest.Model
{
    enum CalculateType
    {
        /// <summary> 
        /// 計算方式未選択 
        /// </summary> 
        None,
        /// <summary> 
        /// 足し算 
        /// </summary> 
        Add,
        /// <summary> 
        /// 引き算 
        /// </summary> 
        Sub,
        /// <summary> 
        /// 掛け算 
        /// </summary> 
        Mul,
        /// <summary> 
        /// 割り算 
        /// </summary> 
        Div 

    }
}
