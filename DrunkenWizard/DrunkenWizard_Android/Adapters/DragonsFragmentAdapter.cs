using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolders;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Adapters
{
    class DragonsFragmentAdapter : RecyclerView.Adapter
    {
        BossFightViewModel _bfVM = ServiceContainer.Resolve<BossFightViewModel>();
        Context _context;
        public EventHandler<Monster> CellClicked;

        public DragonsFragmentAdapter(Context context)
        {
            _context = context;
        }
        public override int ItemCount
        {
            get { return _bfVM.MonsterList.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DragonsViewHolder vh = holder as DragonsViewHolder;
            var data = _bfVM.MonsterList[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(_context).Inflate(Resource.Layout.Cell_DragonsFragment, parent, false);
            DragonsViewHolder viewholder = new DragonsViewHolder(view);
            viewholder.CellClicked += View_CellClicked;
            return viewholder;
        }

        void View_CellClicked(object sender, Monster e)
        {
            CellClicked?.Invoke(this, e);
        }
    }
}