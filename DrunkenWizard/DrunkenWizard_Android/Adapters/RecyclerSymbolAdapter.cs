using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolder;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Adapters
{
    class RecyclerSymbolAdapter : RecyclerView.Adapter
    {
        RulesViewModel _rVM = ServiceContainer.Resolve<RulesViewModel>();
        Context mContext;

        public RecyclerSymbolAdapter(Context contex)
        {
            mContext = contex;
        }

        public override int ItemCount
        {
            get { return _rVM.FAQList.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RulesSymbolViewHolder vh = holder as RulesSymbolViewHolder;
            var data = _rVM.FAQList[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.RulesSymbolCell, parent, false);
            RulesSymbolViewHolder viewholder = new RulesSymbolViewHolder(view);           
            return viewholder;
        }
    }
}