using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Text;
using Android.Support.V7.Widget;
using static Android.Widget.TextView;
using System.Threading.Tasks;
using DrunkenWizard_SharedProject.ViewModels;
using DrunkenWizard_SharedProject.Container;
using DrunkenWizard_Android.ViewModels;
using DrunkenWizard_Android.Adapters;
using DrunkenWizard_SharedProject.Models;
using DrunkenWizard_SharedProject.Enums;
using DrunkenWizard_SharedProject.WebService.Hubs;
using Android.Graphics;
using DrunkenWizard_SharedProject.DTO;

namespace DrunkenWizard_Android.Fragments
{
    public class FragmentJoinGame : Fragment
    {
        FragmentHomeViewModel _fhVM = ServiceContainer.Resolve<FragmentHomeViewModel>();
        ClassViewModel _cVM = ServiceContainer.Resolve<ClassViewModel>();
        TextColorViewModel _tcVM = ServiceContainer.Resolve<TextColorViewModel>();
        PlayerHub playerHub = ServiceContainer.Resolve<PlayerHub>();
        SQLiteViewModel _sqlVM = ServiceContainer.Resolve<SQLiteViewModel>();
        EditText editname;
        RecyclerView classrecycle;
        HorizontalClassAdapter adapter;
        TextView ChosenClass;
        Button Join;
        AlertDialog builderClassDetails;
        SpannableStringBuilder spanbuilder;
        EditText editKey;
        LinearLayoutManager layoutManager;
        ImageView imgRandom;
        ProgressBar loader;
        FrameLayout spinnerframe;
        TextView txtloading;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public static FragmentJoinGame NewInstance()
        {
            var fragJoin = new FragmentJoinGame { Arguments = new Bundle() };
            return fragJoin;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.FragmentJoinGame, null);
            editname = view.FindViewById<EditText>(Resource.Id.JoinEditName);
            ChosenClass = view.FindViewById<TextView>(Resource.Id.txtChosenClass);
            Join = view.FindViewById<Button>(Resource.Id.BtnJoin);
            Join.Click += Join_Click;          
            classrecycle = view.FindViewById<RecyclerView>(Resource.Id.recycle);
            loader = view.FindViewById<ProgressBar>(Resource.Id.progress_loaderJoin);
            spinnerframe = view.FindViewById<FrameLayout>(Resource.Id.progress_FrameJoin);
            txtloading = view.FindViewById<TextView>(Resource.Id.txtprogress_loader);
            adapter = new HorizontalClassAdapter(Context);
            layoutManager = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);
            classrecycle.SetLayoutManager(layoutManager);
            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(classrecycle.Context, DividerItemDecoration.Horizontal);
            classrecycle.AddItemDecoration(dividerItemDecoration);
            classrecycle.SetAdapter(adapter);
            editKey = view.FindViewById<EditText>(Resource.Id.EditKey);
            adapter.CellClicked += CellClicked;
            adapter.CellClicked_CenterItem += CellClickedCenterItem;
            imgRandom = view.FindViewById<ImageView>(Resource.Id.imgRandom);
            imgRandom.Click += ImgRandom_Click;
            var toolbartitel = Activity.FindViewById<TextView>(Resource.Id.toolbartitle);
            toolbartitel.Text = "Join Game";
            return view;
        }

        private void ImgRandom_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(_cVM.ClassList.Count());
            GameClass c = _cVM.ClassList[index];
            spanbuilder = _tcVM.classtextcolor(c.Name);
            ChosenClass.Text = "";
            ChosenClass.SetText(spanbuilder, BufferType.Spannable);
        }

        private void CellClicked(object sender, GameClass e)
        {
            _cVM.SelectedClass = e;
            LayoutInflater li = LayoutInflater.From(Context);
            View promptsView = li.Inflate(Resource.Layout.ClassDetailsChoosingLayout, null);
            builderClassDetails = new AlertDialog.Builder(Context, Resource.Style.AlertDialog_LevelUp).Create();
            builderClassDetails.SetView(promptsView);
            builderClassDetails.Show();
            ImageView imgFragmentClass = promptsView.FindViewById<ImageView>(Resource.Id.imgFragmentClass);
            int resourceId = (int)typeof(Resource.Drawable).GetField(e.Picture).GetValue(null);
            imgFragmentClass.SetImageResource(resourceId);
            TextView txtFragmentClass = promptsView.FindViewById<TextView>(Resource.Id.txtFragmentClass);
            txtFragmentClass.Text = e.Name;
            LinearLayout linearaggressive = promptsView.FindViewById<LinearLayout>(Resource.Id.linearaggressive);
            LinearLayout linearDefensive = promptsView.FindViewById<LinearLayout>(Resource.Id.linearDefensive);
            LinearLayout linearEntertaining = promptsView.FindViewById<LinearLayout>(Resource.Id.linearFun);
            LinearLayout linearSpeed = promptsView.FindViewById<LinearLayout>(Resource.Id.linearSpeed);
            for (int i = 1; i <= e.Aggressive; i++)
            {
                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearaggressive.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearaggressive.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                }
             
            }
            for (int i = 1; i <= e.Defensive; i++)
            {
                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearDefensive.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearDefensive.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                }
               
            }
            for (int i = 1; i <= e.Entertaining; i++)
            {
                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearEntertaining.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearEntertaining.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                } 
            }
            for (int i = 1; i <= e.Speed; i++)
            {
                if (_cVM.SelectedClass.Name == "Disrupted Sorcerer")
                {
                    linearSpeed.GetChildAt(i).SetBackgroundColor(Color.Black);
                }
                else
                {
                    linearSpeed.GetChildAt(i).SetBackgroundColor(Color.ParseColor(e.Color));
                }
              
            }
            Button btnChooseClass = promptsView.FindViewById<Button>(Resource.Id.btnChooseClass);
            btnChooseClass.Click += BtnChooseClass_Click1;
            Button btnChooseClassCancel = promptsView.FindViewById<Button>(Resource.Id.btnChooseClassCancel);
            btnChooseClassCancel.Click += BtnChooseClassCancel_Click;
        }

        private void BtnChooseClassCancel_Click(object sender, EventArgs e)
        {
            builderClassDetails.Dismiss();
        }

        private void BtnChooseClass_Click1(object sender, EventArgs e)
        {
            spanbuilder = new SpannableStringBuilder();
            spanbuilder = _tcVM.classtextcolor(_cVM.SelectedClass.Name);
            ChosenClass.SetText(spanbuilder, BufferType.Spannable);
            builderClassDetails.Dismiss();
        }

        private void CellClickedCenterItem(object sender, View e)
        {
            scrollToCenter(e);
        }

        private void scrollToCenter(View v)
        {
            int itemToScroll = classrecycle.GetChildAdapterPosition(v);
            int centerOfScreen = classrecycle.Width / 2 - v.Width / 2;
            layoutManager.ScrollToPositionWithOffset(itemToScroll, centerOfScreen);
        }

        private void Join_Click(object sender, EventArgs e)
        {
            var player = _sqlVM.GetLocalPlayer();
            if (player != null)
            {
                Toast.MakeText(Application.Context, "You are already in a game. Leave it before you can join another", ToastLength.Long).Show();
                return;
            }
            if (string.IsNullOrWhiteSpace(editname.Text))
            {
                Toast.MakeText(Context, "You forgot a name", ToastLength.Short).Show();
                return;
            }
            if (string.IsNullOrWhiteSpace(ChosenClass.Text))
            {
                Toast.MakeText(Context, "Choose a class", ToastLength.Short).Show();
                return;
            }
            if (string.IsNullOrWhiteSpace(editKey.Text))
            {
                Toast.MakeText(Context, "Enter a Key", ToastLength.Short).Show();
                return;
            }

            JoinPlayerDTO playerDTO = new JoinPlayerDTO()
            {
                Name = editname.Text,
                Level = 0,
                ClassName = ChosenClass.Text,
                SlayedBeast = BeastEnum.none,
                IsHost = false,
                LocalPLayer = false,
                GameKey = Convert.ToInt32(editKey.Text),
                PremiumAccount = true
            };

            //Player JoinPlayer = new Player
            //{
            //    Name = editname.Text,
            //    Level = 0,
            //    GameClass = _fhVM.ClassPicture(ChosenClass.Text),
            //    SlayedBeast = BeastEnum.none,
            //    IsHost = false,
            //    LocalPLayer = false,
            //    GameKey = Convert.ToInt32(editKey.Text),
            //    PremiumAccount = true
            //};

            Activity.RunOnUiThread(() =>
            {
                loader.Visibility = ViewStates.Visible;
                loader.BringToFront();
                spinnerframe.Visibility = ViewStates.Visible;
                spinnerframe.BringToFront();
                txtloading.Visibility = ViewStates.Visible;
                txtloading.BringToFront();
            });
            playerHub.ReturnedPlayer += ReturnedPlayer;
            Task.Run(() =>
            {
                playerHub.JoinGame(playerDTO);
            });
        }

        void ReturnedPlayer(object sender, Player player)
        {           
            playerHub.ReturnedPlayer -= ReturnedPlayer;
            if (player == null)
            {
                Activity.RunOnUiThread(() =>
                {  
                    loader.Visibility = ViewStates.Gone;
                    spinnerframe.Visibility = ViewStates.Gone;
                    txtloading.Visibility = ViewStates.Gone;
                    Toast.MakeText(Context, "Error, Your Key is probably not correct", ToastLength.Short).Show();
                    return;
                });
            }
            else
            {
                _sqlVM.SavePlayer(player.Id, player.GameKey, player.GameId, player.IsHost);
                Task.Run(() =>
                {
                    var intent = new Intent(Context.ApplicationContext, typeof(CurrentGameActivity))
                      .SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(intent);
                    Activity.SupportFragmentManager.PopBackStack();
                    // Task.Delay(1000).Wait();
                    playerHub.ExistingPLayers(player.GameKey);
                    
                });

                Activity.RunOnUiThread(() =>
                {
                    loader.Visibility = ViewStates.Gone;
                    spinnerframe.Visibility = ViewStates.Gone;
                    txtloading.Visibility = ViewStates.Gone;
                });
            }
        }
    }
}