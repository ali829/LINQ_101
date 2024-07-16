using LinqLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
  public partial class Dashboaard : Form
  {
    List<Person> people = ListManager.LoadSampleData();

    public Dashboaard()
    {
      InitializeComponent();

      InitializeBindings();
    }

    private void InitializeBindings()
    {
      allPeopleDropDown.DataSource = people;
      allPeopleDropDown.DisplayMember = "FullName";
    }

    private void UpdateBindings()
    {
        filteredPeopleList.Items.Clear();
        var selectedExpYears = yearsExperiencePicker.Value;
        List<Person> filteredPeople = people.Where(p => p.YearsExperience >= selectedExpYears).ToList();
        foreach (Person person in filteredPeople)
        {
                filteredPeopleList.Items.Add(person.FullName);
        }
    }

    private void allPeopleDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
      Person selectedPerson = (Person)allPeopleDropDown.SelectedItem;

      yearsExperiencePicker.Value = selectedPerson.YearsExperience;
    }

    private void updatePersonButton_Click(object sender, EventArgs e)
    {
      UpdateBindings();
    }

        private void Dashboaard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
