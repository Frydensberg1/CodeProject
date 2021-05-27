using System;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolders;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Adapters
{
    public class NewHostAdapter : RecyclerView.Adapter
    {
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        Context _context;
        public EventHandler<Player> CellClicked;

        public NewHostAdapter(Context context) 
        {
            _context = context;
            _cgVM.PlayerListNewHost = _cgVM.PlayerList.Where(x => x.LocalPLayer == false).ToList();
        }

        public override int ItemCount
        {
            get { return _cgVM.PlayerListNewHost.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            NewHostViewHolder vh = holder as NewHostViewHolder;
            var data = _cgVM.PlayerListNewHost[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(_context).Inflate(Resource.Layout.Cell_NewHost, parent, false);
            NewHostViewHolder viewholder = new NewHostViewHolder(view);
            viewholder.CellClicked += View_CellClicked;
            return viewholder;
        }

        void View_CellClicked(object sender, Player e)
        {
            CellClicked?.Invoke(this, e);
        }
    }
}