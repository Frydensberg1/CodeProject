using System;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolder;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;
using Context = Android.Content.Context;

namespace DrunkenWizard_Android.Adapters
{
    class ChooseClassAdapter : RecyclerView.Adapter
    {
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        public EventHandler<GameClass> CellClicked;
        Context mContext;

        public ChooseClassAdapter(Context contex)
        {
            mContext = contex;
        }
        public override int ItemCount
        {
            get { return _cVM.ClassList.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ChooseClassViewHolder vh = holder as ChooseClassViewHolder;
            var data = _cVM.ClassList[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.ChooseClass_Cell, parent, false);
            ChooseClassViewHolder viewholder = new ChooseClassViewHolder(view);
            viewholder.CellClicked += View_CellClicked;
            return viewholder;
        }

        void View_CellClicked(object sender, GameClass e)
        {
            CellClicked?.Invoke(this, e);
        }
    }
}
