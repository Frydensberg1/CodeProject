using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolder;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Adapters
{
    class HorizontalClassAdapter : RecyclerView.Adapter
    {
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        Context mContext;
        public EventHandler<GameClass> CellClicked;
        public EventHandler<View> CellClicked_CenterItem;
        public HorizontalClassAdapter(Context contex)
        {
            mContext = contex;
        }
        public override int ItemCount
        {
            get { return _cVM.ClassList.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
           HorizontalClassViewHolder vh = holder as HorizontalClassViewHolder;
            var data = _cVM.ClassList[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.Cell_HorizontalClass, parent, false);
            HorizontalClassViewHolder viewholder = new HorizontalClassViewHolder(view);
            viewholder.CellClicked += View_CellClicked;
            viewholder.CellClicked_CenterItem += View_CellClickedCenterItem;
            return viewholder;
        }

        void View_CellClicked(object sender, GameClass e)
        {
            CellClicked?.Invoke(this, e);
        }

        void View_CellClickedCenterItem(object sender, View e)
        {
            CellClicked_CenterItem?.Invoke(this, e);
        }
    }
}