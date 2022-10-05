using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;


namespace TaskSchedulerManager
{
    public partial class TaskSchedulerManager : Form
    {
        public TaskSchedulerManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TaskService tasksrvc = new TaskService("MIDHYP-ess", "CT-MID-Svc-Hyp", "zygomis" ,"Zyg0$ervice"))
            {
                Task task1 = tasksrvc.FindTask("BPM Update");
                task1.Run();
            }
        }

        private void bCalcBUDall09_Click(object sender, EventArgs e)
        {
            using (TaskService tasksrvc = new TaskService("MIDHYP-ess", "CT-MID-Svc-Hyp", "zygomis", "Zyg0$ervice"))
            {
                Task task2= tasksrvc.FindTask("BPMCalc-BudAll09");
                task2.Run();
            }
        }

        private void bCalcOps_Click(object sender, EventArgs e)
        {
            using (TaskService tasksrvc = new TaskService("MIDHYP-ess", "CT-MID-Svc-Hyp", "zygomis", "Zyg0$ervice"))
            {
                Task task3 = tasksrvc.FindTask("BPMCalc-Ops");
                task3.Run();
            }
        }
    }
}
