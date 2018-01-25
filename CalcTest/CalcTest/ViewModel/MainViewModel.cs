﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcTest.Common;
using CalcTest.Model;

namespace CalcTest.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private double lhs;

        private double rhs;

        private double answer;

        private CalculateTypeViewModel selectedCalculateType;

        private DelegateCommand calculateCommand;
        private DelegateCommand clearCommand;

        public MainViewModel()
        {
            this.CalculateTypes = CalculateTypeViewModel.Create();
            this.SelectedCalculateType = this.CalculateTypes.First();
        }

        /// <summary> 
        /// 計算方式 
        /// </summary> 
        public IEnumerable<CalculateTypeViewModel> CalculateTypes { get; private set; }

        /// <summary> 
        /// 現在選択されている計算方式 
        /// </summary> 
        public CalculateTypeViewModel SelectedCalculateType
        {
            get
            {
                return this.selectedCalculateType;
            }

            set
            {
                this.selectedCalculateType = value;
                this.RaisePropertyChanged("SelectedCalculateType");
            }
        }

        /// <summary> 
        /// 計算の左辺値 
        /// </summary> 
        public double Lhs
        {
            get
            {
                return this.lhs;
            }

            set
            {
                this.lhs = value;
                this.RaisePropertyChanged("Lhs");
            }
        }

        /// <summary> 
        /// 計算の右辺値 
        /// </summary> 
        public double Rhs
        {
            get
            {
                return this.rhs;
            }

            set
            {
                this.rhs = value;
                this.RaisePropertyChanged("Rhs");
            }
        }

        /// <summary> 
        /// 計算結果 
        /// </summary> 
        public double Answer
        {
            get
            {
                return this.answer;
            }

            set
            {
                this.answer = value;
                this.RaisePropertyChanged("Answer");
            }
        }

        /// <summary> 
        /// 計算処理のコマンド 
        /// </summary> 
        public DelegateCommand CalculateCommand
        {
            get
            {
                if (this.calculateCommand == null)
                {
                    this.calculateCommand = new DelegateCommand(CalculateExecute, CanCalculateExecute);
                }

                return this.calculateCommand;
            }
        }

        public DelegateCommand ClearCommand
        {
            get
            {
                if (this.clearCommand == null)
                {
                    this.clearCommand = new DelegateCommand(ClearExecute, CanClearExecute);
                }

                return this.clearCommand;
            }
        }


        /// <summary> 
        /// 計算処理のコマンドの実行を行います。 
        /// </summary> 
        private void CalculateExecute()
        {
            // 現在の入力値を元に計算を行う 
            var calc = new Calculator();
            this.Answer = calc.Execute(this.Lhs, this.Rhs, this.SelectedCalculateType.CalculateType);
        }

        /// <summary> 
        /// 計算処理が実行可能かどうかの判定を行います。 
        /// </summary> 
        /// <returns></returns> 
        private bool CanCalculateExecute()
        {
            // 現在選択されている計算方法がNone以外ならコマンドの実行が可能 
            return this.SelectedCalculateType.CalculateType != CalculateType.None;
        }

        private void ClearExecute()
        {
            this.Lhs = 0;
            this.Rhs = 0;
            this.Answer = 0;
            this.SelectedCalculateType = this.CalculateTypes.First();
        }

        private bool CanClearExecute()
        {
            return true;
        }

    }
}