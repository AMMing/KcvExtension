using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.ViewModels
{
    public class SelectedItemViewModel : ViewModel
    {
        #region IsSelected

        private bool _IsSelected;

        public bool IsSelected
        {
            get { return this._IsSelected; }
            set
            {
                if (this._IsSelected != value)
                {
                    this._IsSelected = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion
    }
}
