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
    public class FragmentClassAdapter : RecyclerView.Adapter
    {
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        Context _context;
        public EventHandler<GameClass> SpellsClicked;

        public FragmentClassAdapter(Context context)
        {
            _context = context;
        }
        public override int ItemCount
        {
            get { return _cVM.ClassList.Count; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            FragmentClassViewHolder vh = holder as FragmentClassViewHolder;
            var data = _cVM.ClassList[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(_context).Inflate(Resource.Layout.Cell_ClassFragment, parent, false);
            FragmentClassViewHolder viewholder = new FragmentClassViewHolder(view);
            viewholder.txtspellsCellClassClicked += View_SpellsClicked;
            return viewholder;
        }

        void View_SpellsClicked(object sender, GameClass e)
        {
            SpellsClicked?.Invoke(this, e);
        }
    }
}