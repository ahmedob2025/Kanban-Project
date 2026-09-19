
using KanbanProjectManagementSystem.Common.Entities;

namespace KanbanProjectManagementSystem.PresentationLayer.Forms
{
    public partial class KanbanBoardForm : Form
    {
        private readonly KanbanService _kanbanService = new();
        private readonly TaskService _taskService = new();
        private readonly int _projectId;

        public KanbanBoardForm(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadBoard();
        }

        private void LoadBoard()
        {
            flowNew.Controls.Clear();
            flowInProgress.Controls.Clear();
            flowDone.Controls.Clear();

            var (newTasks, inProgress, done) = _kanbanService.GetBoardTasks(_projectId);

            foreach (var t in newTasks) flowNew.Controls.Add(CreateCard(t, "New"));
            foreach (var t in inProgress) flowInProgress.Controls.Add(CreateCard(t, "InProgress"));
            foreach (var t in done) flowDone.Controls.Add(CreateCard(t, "Done"));
        }

        private Panel CreateCard(KanbanTask task, string currentStatus)
        {
            var panel = new Panel
            {
                Width = 180,
                Height = 80,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(5)
            };

            var lbl = new Label
            {
                Text = task.Title,
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(5),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            panel.Controls.Add(lbl);

            // زر النقل التالي
            if (currentStatus != "Done")
            {
                var btn = new Button
                {
                    Text = currentStatus == "New" ? "▶ بدء" : "✔ إكمال",
                    Dock = DockStyle.Bottom,
                    Height = 25,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(33, 150, 243),
                    ForeColor = Color.White
                };
                string nextStatus = currentStatus == "New" ? "InProgress" : "Done";
                btn.Click += (s, e) =>
                {
                    try
                    {
                        _taskService.ChangeStatus(task.TaskID, nextStatus, SessionManager.CurrentUser!.UserID);
                        LoadBoard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                panel.Controls.Add(btn);
            }

            return panel;
        }
    }
}