using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DrunkenWizard_Android
{
    public class MorphAnimation
    {
        private RelativeLayout parentView;
        private View buttonContainer;
        private ViewGroup viewsContainer;
        private int initialWidth;
        private RelativeLayout.LayoutParams initialGravity;
        public bool isPressed { get; set; }
        public MorphAnimation(View buttonContainer, RelativeLayout parentView, ViewGroup viewsContainer)
        {
            this.buttonContainer = buttonContainer;
            this.parentView = parentView;
            this.viewsContainer = viewsContainer;
            LayoutTransition layoutTransition = parentView.LayoutTransition;
            layoutTransition.SetDuration(400);
            layoutTransition.EnableTransitionType(LayoutTransitionType.Changing);

            isPressed = false;
        }




        public void morphIntoButtonRollSpells()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.AlignParentBottom);
            layoutParams.SetMargins(0, 5, 0, 0);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }


        public void morphIntoForm()
        {
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            initialWidth = layoutParams.Width;
            initialGravity = layoutParams;
            layoutParams.AddRule(LayoutRules.CenterInParent);
            layoutParams.SetMargins(10, 5, 10, 5);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;

            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Visible;
            }

            isPressed = true;
        }

        public void morphIntoButton()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            //layoutParams.AddRule(LayoutRules.Below,Resource.Id.textView1);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }


        public void morphIntoButtonSpell2()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell1);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }

        public void morphIntoButtonSpell3()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell2);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }

        public void morphIntoButtonSpell4()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell3);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }

        public void morphIntoButtonSpell5()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell4);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }


        public void morphIntoButtonSpell6()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell5);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }


        public void morphIntoButtonSpell7()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell6);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }



        public void morphIntoButtonSpell8()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell7);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }



        public void morphIntoButtonSpell9()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell8);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }


        public void morphIntoButtonSpell10()
        {
            for (int i = 1; i < viewsContainer.ChildCount; i++)
            {
                viewsContainer.GetChildAt(i).Visibility = ViewStates.Gone;
            }
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(buttonContainer.LayoutParameters);
            layoutParams.AddRule(LayoutRules.Below, Resource.Id.form_Spell9);
            layoutParams.SetMargins(20, 10, 20, 10);
            layoutParams.Width = initialWidth;
            buttonContainer.LayoutParameters = layoutParams;
            isPressed = false;
        }
    }
}