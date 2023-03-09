using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMasterPage.Components.Services
{
    public abstract class StyleProvider : IStyleProvider
    {
        public abstract string ModalShow();

        public abstract string ModalBodyMaxHeight(int maxHeight);

        public abstract string ProgressBarValue(int value);

        public abstract string ProgressBarSize(Size size);

        public virtual string RowGutter((int Horizontal, int Vertical) gutter)
        {
            var sb = new StringBuilder();

            if (gutter.Horizontal > 0)
                sb.Append($"margin-left: -{gutter.Horizontal / 2}px; margin-right: -{gutter.Horizontal / 2}px;");

            if (gutter.Vertical > 0)
                sb.Append($"margin-top: -{gutter.Vertical / 2}px");

            return sb.ToString();
        }

        public virtual string ColumnGutter((int Horizontal, int Vertical) gutter)
        {
            var sb = new StringBuilder();

            if (gutter.Horizontal > 0)
                sb.Append($"padding-left: {gutter.Horizontal / 2}px; padding-right: {gutter.Horizontal / 2}px;");

            if (gutter.Vertical > 0)
                sb.Append($"padding-top: {gutter.Vertical / 2}px; padding-bottom: {gutter.Vertical / 2}px");

            return sb.ToString();
        }

    }
}
