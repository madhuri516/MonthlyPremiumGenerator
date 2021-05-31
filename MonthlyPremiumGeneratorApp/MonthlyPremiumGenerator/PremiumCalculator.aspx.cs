using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonthlyPremiumGenerator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string occupation;
        public int age;
        public double deathSumInsuredAmount;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        public double CalculatePremium(string occupation, int age, double deathSumInsuredAmount)
        {
            double deathPremium = 0.0;
            switch (occupation)
            {
                case "Cleaner":
                    deathPremium = (deathSumInsuredAmount * 1.50 * age) / 1000 * 12;
                    break;
                case "Doctor":
                    deathPremium = (deathSumInsuredAmount * 1.0 * age) / 1000 * 12;
                    break;
                case "Author":
                    deathPremium = (deathSumInsuredAmount * 1.25 * age) / 1000 * 12;
                    break;
                case "Farmer":
                    deathPremium = (deathSumInsuredAmount * 1.75 * age) / 1000 * 12;
                    break;
                case "Mechanic":
                    deathPremium = (deathSumInsuredAmount * 1.75 * age) / 1000 * 12;
                    break;
                case "Florist":
                    deathPremium = (deathSumInsuredAmount * 1.50 * age) / 1000 * 12;
                    break;
            }
            return deathPremium;
        }

        protected void OccupationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.Validate("RequiredFieldValidator");
            if (Page.IsValid)
            {
                occupation = OccupationDropDownList.SelectedValue;

                double premiumAmount = CalculatePremium(occupation, age, deathSumInsuredAmount);

                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(this.GetType(), "msgboxalert", "alert('Your monthly premium amount is: " + premiumAmount + "')", true);
            }
            else
                return;
        }

        protected void AgeTextInput_TextChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32(AgeTextInput.Text);
        }

        protected void DeathSumTextInput_TextChanged(object sender, EventArgs e)
        {
            deathSumInsuredAmount = Convert.ToDouble(DeathSumTextInput.Text);
        }

        protected void DOBCalendarInput_SelectionChanged(object sender, EventArgs e)
        {
            CalendarTextBox.Text = DOBCalendarInput.SelectedDate.ToShortDateString();
        }

    }
}