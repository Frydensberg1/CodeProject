using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolder;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Adapters
{
    class ExtraFragmentAdapter: RecyclerView.Adapter
    {
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        Context mContext;
        public ExtraFragmentAdapter(Context contex)
        {
            mContext = contex;
        }
        public override int ItemCount
        {
            get
            {
                if (_cVM.ExtraFragmentItemsList == null)
                    return 0;

                return _cVM.ExtraFragmentItemsList.Count;
            }          
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ExtraFragmentViewHolder vh = holder as ExtraFragmentViewHolder;
            var data = _cVM.ExtraFragmentItemsList[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.ExtraFragment_Cell, parent, false);
            ExtraFragmentViewHolder viewholder = new ExtraFragmentViewHolder(view);         
            return viewholder;
        }
    }
}