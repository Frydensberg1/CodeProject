using System;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolder;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Adapters
{
    class CurrentGameRecyclerAdapter : RecyclerView.Adapter
    {
        CurrentGameViewModel _cgVM = ServiceContainer.Resolve<CurrentGameViewModel>();
        public EventHandler<Player> LongCellClicked;
        public EventHandler<Player> MinusClicked;
        public EventHandler<Player> PlusClicked;
        public EventHandler<Player> BossClicked;
        public EventHandler<Player> DragonHeadClicked;
        public EventHandler<Player> SpellImage1Clicked;
        public EventHandler<Player> SpellImage2Clicked;
        public EventHandler<Player> SpellImage3Clicked;
        public EventHandler<Player> MenuClicked;
        public EventHandler<Player> RollingSpellsClicked;
        public EventHandler<Player> CircleImageClicked;
        Context mContext;
        public CurrentGameRecyclerAdapter(Context contex)
        {
            mContext = contex;
        }
        public override int ItemCount
        {
            get { return _cgVM.PlayerList?.Count ?? 0; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CurrentGameViewHolder vh = holder as CurrentGameViewHolder;
            var data = _cgVM.PlayerList.OrderByDescending(x => x.Level).ToList()[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.CurrentGameRecycler_Cell, parent, false);
            CurrentGameViewHolder viewholder = new CurrentGameViewHolder(view);
            viewholder.MinusClicked += View_MinusClicked;
            viewholder.PlusClicked += View_PlusClicked;
            viewholder.BossClicked += View_BossClicked;
            viewholder.DragonHeadClicked += View_DragonHeadClicked;
            //viewholder.SpellImage1Clicked += View_SpellImage1Clicked;
            //viewholder.SpellImage1Clicked += View_SpellImage2Clicked;
            //viewholder.SpellImage1Clicked += View_SpellImage3Clicked;
            viewholder.MenuClicked += View_MenuClicked;
            viewholder.RollSpellsClicked += View_RollSpellsClicked;
            viewholder.CircleImageClicked += View_CircleImageClicked;
            return viewholder;
        }

        void View_MinusClicked(object sender, Player e)
        {
            MinusClicked?.Invoke(this, e);
        }
        void View_PlusClicked(object sender, Player e)
        {
            PlusClicked?.Invoke(this, e);
        }
        void View_BossClicked(object sender, Player e)
        {
            BossClicked?.Invoke(this, e);
        }
        void View_DragonHeadClicked(object sender, Player e)
        {
            DragonHeadClicked?.Invoke(this, e);
        }

        //void View_SpellImage1Clicked(object sender, Player e)
        //{
        //    SpellImage1Clicked?.Invoke(this, e);
        //}
        //void View_SpellImage2Clicked(object sender, Player e)
        //{
        //    SpellImage2Clicked?.Invoke(this, e);
        //}
        //void View_SpellImage3Clicked(object sender, Player e)
        //{
        //    SpellImage3Clicked?.Invoke(this, e);
        //}
        void View_MenuClicked(object sender, Player e)
        {
            MenuClicked?.Invoke(this, e);
        }
        void View_RollSpellsClicked(object sender, Player e)
        {
            RollingSpellsClicked?.Invoke(this, e);
        }
        void View_CircleImageClicked(object sender, Player e)
        {
            CircleImageClicked?.Invoke(this, e);
        }

    }
}