using System;
using Android.Content;
using Android.Support.V7.Widget;

namespace DrunkenWizard_Android
{
    class AutoFitGridLayoutManager: GridLayoutManager
    {
        private int columnWidth;
        private bool columnWidthChanged = true;
        public AutoFitGridLayoutManager(Context context, int columnWidth):base(context,1)
        {            
            setColumnWidth(columnWidth);
        }

        public void setColumnWidth(int newColumnWidth)
        {
            if (newColumnWidth > 0 && newColumnWidth != columnWidth)
            {
                columnWidth = newColumnWidth;
                columnWidthChanged = true;
            }
        }

        public override void OnLayoutChildren(RecyclerView.Recycler recycler, RecyclerView.State state)
        {
            if (columnWidthChanged && columnWidth > 0)
            {
                int totalSpace;
                if (Orientation == Vertical)
                {
                    totalSpace = Width - PaddingRight - PaddingLeft;
                }
                else
                {
                    totalSpace = Height - PaddingTop - PaddingBottom;
                }
                int spanCount = Math.Max(1, totalSpace / columnWidth);
                SpanCount = spanCount;
              
                columnWidthChanged = false;
            }
            base.OnLayoutChildren(recycler, state);
        }
    }
}