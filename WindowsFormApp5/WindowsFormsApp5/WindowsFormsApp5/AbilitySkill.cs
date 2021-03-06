﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class AbilitySkill : UserControl
    {
        int modifier, proficience;
        public string skill_tag;
        cha_save parentForm;


        public AbilitySkill()
        {
            InitializeComponent();
            modifier = 0;
            proficience = 2;
        }

        public void ChangeState(bool single,bool doubl)
        {
            prof.Checked = single;
            doubleProf.Checked = doubl;
        }

        public void SetAll_Skills(string n, string s, int mo, int pro)
        {
            skill_tag = n;
            skill.Text = n + " ( " + s + " )";
            modifier = mo;
            if (mo >= 0) mod.Text = "+" + mo.ToString();
            else mod.Text = mo.ToString();
            proficience = pro;
            doubleProf.Location = new Point(skill.Width + skill.Location.X + 5, doubleProf.Location.Y);
        }

        public void SetAll_Tools(string n, int pro)
        {
            skill.Text = n;
            mod.Text = "+0";
            proficience = pro;
            doubleProf.Location = new Point(skill.Width + skill.Location.X + 5, doubleProf.Location.Y);
        }

        public string GetName()
        {
            return skill.Text;
        }

        public void UpdateMod(int x, int p)  
        {                                    
            modifier = x;
            proficience = p;
            if (doubleProf.Checked)
            {
                if (2 * p + x >= 0) mod.Text = "+" + (2 * p + x).ToString();
                else mod.Text = (2 * p + x).ToString();
            }
            else if (prof.Checked)
            {
                if (p + x >= 0) mod.Text = "+" + (p + x).ToString();
                else mod.Text = (p + x).ToString();
            }
            else
            {
                if (x >= 0) mod.Text = "+" + x.ToString();
                else mod.Text = x.ToString();
            }
        }

        private void AbilitySkill_Load(object sender, EventArgs e)
        {
            
            parentForm = (cha_save) this.FindForm() ;
            
        }
        public bool getProf ()
        {
            return prof.Checked;
        }
        public bool getDouble()
        {
            return doubleProf.Checked;
        }
        private void doubleProf_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMod(modifier, proficience);
            parentForm.updateStat(skill_tag, prof.Checked, doubleProf.Checked);
        }

        public bool Checked()
        {
            return prof.Checked;
        }

        private void prof_CheckedChanged(object sender, EventArgs e)
        {
            if (prof.Checked)
            {
                doubleProf.Enabled = true;
                UpdateMod(modifier, proficience);
            }
            else
            {
                doubleProf.Checked = false;
                doubleProf.Enabled = false;
                UpdateMod(modifier, proficience);
            }
            parentForm.updateStat(skill_tag, prof.Checked, doubleProf.Checked);
        }
    }
}
