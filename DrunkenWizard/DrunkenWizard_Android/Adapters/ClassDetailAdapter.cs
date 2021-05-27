using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using DrunkenWizard_Android.ViewHolder;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_SharedProject.ViewModels;

namespace DrunkenWizard_Android.Adapters
{
    class ClassDetailAdapter : RecyclerView.Adapter
    {
        private Context _context;
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        public ClassDetailAdapter(Context context) 
        {
            _context = context;
        }
        public override int ItemCount
        {
            get { return _cVM.SelectedClass.Spells.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ClassDetailViewHolder vh = holder as ClassDetailViewHolder;
            var data = _cVM.SelectedClass.Spells.ToList()[position];
            vh.SetupCell(data);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(_context).Inflate(Resource.Layout.Cell_DetailClass, parent, false);
            ClassDetailViewHolder viewholder = new ClassDetailViewHolder(view);
            return viewholder;
        }
    }
}