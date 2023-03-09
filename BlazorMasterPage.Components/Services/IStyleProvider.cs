using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Services
{
    public interface IStyleProvider
    {
        string ModalShow();
        string ModalBodyMaxHeight(int maxHeight);
        string ProgressBarValue(int value);
        string ProgressBarSize(Size size);
        string RowGutter((int Horizontal, int Vertical) gutter);
        string ColumnGutter((int Horizontal, int Vertical) gutter);

    }
}
