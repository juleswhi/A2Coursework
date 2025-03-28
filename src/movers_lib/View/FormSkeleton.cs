﻿using Forms;
using Model;

namespace View;

/// <summary>
/// FormSkeleton is the master form
/// </summary>
public partial class FormSkeleton : Form, IFormMaster {
    public Form CurrentForm => panelHolder.
        Controls.
        OfType<Form>().
        ToList().
        FirstOrDefault()!;

    public Form CurrentlyDisplayedForm { get => CurrentForm; }

    public FormSkeleton() {
        InitializeComponent();
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        BackColor = Almond();

        // Initialise Buttons 
        btnHome.Click += (s, e) => ShowForm<FormHome>();
        btnJobs.Click += (s, e) => ShowGCF<FormViewModel, Clean>();
        btnStock.Click += (s, e) => ShowGCF<FormViewModel, Stock>();
        btnStaff.Click += (s, e) => ShowGCF<FormViewModel, Customer>();
        btnReports.Click += (s, e) => ShowForm<FormReports>();
        btnDeliveries.Click += (s, e) => ShowForm<FormDeliveries>();
    }

    /// <summary>
    /// Accesses the Panel that holds the form
    /// </summary>
    /// <returns></returns>
    public Panel GetHolder() => panelHolder;

    /// <summary>
    /// Displays a chosen <c>Form</c> in <c>panelHolder</c>
    /// </summary>
    /// <param name="form">The form to display</param>
    public void LoadForm(Form form) {
        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Enabled = true;
        form.Visible = true;

        panelHolder.Controls.Clear();
        panelHolder.Controls.Add(form);
        panelHolder.Show();
        form.Show();

        Refresh();
    }
}
