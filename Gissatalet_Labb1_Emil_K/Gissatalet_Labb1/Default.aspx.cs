using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gissatalet_Labb1.Model;
namespace Gissatalet_Labb1
{
    public partial class Default : System.Web.UI.Page
    {
        public SecretNumber Secretnumber
        {
            get
            {
                return Session["SecretNumber"] as SecretNumber;
            }
            set
            {
                Session["Secretnumber"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Secretnumber == null)
            {
                this.Secretnumber = new SecretNumber();
            }
 
        }

        protected void gissaButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string list = String.Join(", ", Secretnumber.PreviousGuesses);
                try
                {
                    
                        
                        var result = Secretnumber.MakeGuess(int.Parse(gissaTextBox.Text));
           
                    
                    if (result == Outcome.Correct)
                    {
                        winLabel.Visible = true;
                        winLabel.Text = "Grattis du gissade rätt!";
                        gissaButton.Enabled = false;
                        gissaTextBox.Enabled = false;
                    }
                    else if (result == Outcome.High)
                    {
                        infoGuessLabel.Visible = true;
                        infoGuessLabel.Text = "Gissningen är för hög, försök igen.";
                        gissaTextBox.Focus();
                          
                    }
                    else if (result == Outcome.Low)
                    {
                        infoGuessLabel.Visible = true;
                        infoGuessLabel.Text = "Gissningen är för låg, försök igen";
                        gissaTextBox.Focus();
                    }
                    else if (result == Outcome.NoMoreGuesses)
                    {
                        infoGuessLabel.Visible = true;
                        infoGuessLabel.Text = string.Format("Du har inga fler gissningar. Det hemliga talet är {0} , tryck på slumpa tal för att gissa igen.", Secretnumber.Number);
                        gissaTextBox.Enabled = false;
                        gissaButton.Enabled = false;
                        randomButton.Focus();
                    }
                    else if (result == Outcome.PreviousGuess)
                    {
                        
                        errorGuessLabel.Visible = true;
                        errorGuessLabel.Text = "Fel. Du har gissat på samma tal.";
                        gissaTextBox.Focus();
                    }

                    totalGuessesLabel.Text = string.Format("Du har gissat på följande tal: {0}", list);
                    lastGuessLabel.Text = string.Format("Senaste gissade talet: {0}", gissaTextBox.Text);
                    totalGuessesLabel.Visible = true;
                    lastGuessLabel.Visible = true;
                }

                catch (Exception ex)
                {
                    var validator = new CustomValidator
                    {
                        IsValid = false,
                        ErrorMessage = ex.Message
                    };
                    Page.Validators.Add(validator);
                }
            }
        }
        protected void randomButton_Click(object sender, EventArgs e)
        {
            gissaTextBox.Enabled = true;
            gissaButton.Enabled = true;
            Secretnumber.Initialize();
        }
    }
}