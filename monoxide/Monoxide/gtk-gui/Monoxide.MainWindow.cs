// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Monoxide {
    
    
    public partial class MainWindow {
        
        private Gtk.Action refresh;
        
        private Gtk.Action File;
        
        private Gtk.Action Quit;
        
        private Gtk.Action Tools;
        
        private Gtk.Action AddinManagerAction;
        
        private Gtk.Action View;
        
        private Gtk.Action Open;
        
        private Gtk.Action Help;
        
        private Gtk.Action About;
        
        private Gtk.Action Save;
        
        private Gtk.VBox vbox2;
        
        private Gtk.MenuBar menubar1;
        
        private Gtk.Toolbar toolbar;
        
        private Gtk.HPaned hpaned1;
        
        private Gtk.ScrolledWindow scrolledwindow1;
        
        private Gtk.TreeView treeview;
        
        private Gtk.VBox vbox1;
        
        private Gtk.Expander objectExpander;
        
        private Gtk.TextView textview;
        
        private Gtk.Label objectLabel;
        
        private Gtk.Notebook notebook;
        
        private Gtk.ScrolledWindow scrolledwindow2;
        
        private Gtk.Image image;
        
        private Gtk.Statusbar statusbar1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize();
            // Widget Monoxide.MainWindow
            Gtk.UIManager w1 = new Gtk.UIManager();
            Gtk.ActionGroup w2 = new Gtk.ActionGroup("Default");
            this.refresh = new Gtk.Action("refresh", null, null, "gtk-refresh");
            w2.Add(this.refresh, null);
            this.File = new Gtk.Action("File", Mono.Unix.Catalog.GetString("_File"), null, null);
            this.File.ShortLabel = Mono.Unix.Catalog.GetString("_File");
            w2.Add(this.File, null);
            this.Quit = new Gtk.Action("Quit", Mono.Unix.Catalog.GetString("_Quit"), null, "gtk-quit");
            this.Quit.ShortLabel = Mono.Unix.Catalog.GetString("_Quit");
            w2.Add(this.Quit, null);
            this.Tools = new Gtk.Action("Tools", Mono.Unix.Catalog.GetString("_Tools"), null, null);
            this.Tools.ShortLabel = Mono.Unix.Catalog.GetString("_Tools");
            w2.Add(this.Tools, null);
            this.AddinManagerAction = new Gtk.Action("AddinManagerAction", Mono.Unix.Catalog.GetString("Addin Manager..."), null, "AddinManager");
            this.AddinManagerAction.ShortLabel = Mono.Unix.Catalog.GetString("Addin Manager...");
            w2.Add(this.AddinManagerAction, null);
            this.View = new Gtk.Action("View", Mono.Unix.Catalog.GetString("_View"), null, null);
            this.View.ShortLabel = Mono.Unix.Catalog.GetString("_View");
            w2.Add(this.View, null);
            this.Open = new Gtk.Action("Open", Mono.Unix.Catalog.GetString("_Open..."), null, "gtk-open");
            this.Open.ShortLabel = Mono.Unix.Catalog.GetString("_Open...");
            w2.Add(this.Open, null);
            this.Help = new Gtk.Action("Help", Mono.Unix.Catalog.GetString("_Help"), null, null);
            this.Help.ShortLabel = Mono.Unix.Catalog.GetString("_Help");
            w2.Add(this.Help, null);
            this.About = new Gtk.Action("About", Mono.Unix.Catalog.GetString("_About..."), null, "gtk-about");
            this.About.ShortLabel = Mono.Unix.Catalog.GetString("_About...");
            w2.Add(this.About, null);
            this.Save = new Gtk.Action("Save", Mono.Unix.Catalog.GetString("_Save..."), null, "gtk-save");
            this.Save.ShortLabel = Mono.Unix.Catalog.GetString("_Save...");
            w2.Add(this.Save, null);
            w1.InsertActionGroup(w2, 0);
            this.AddAccelGroup(w1.AccelGroup);
            this.Name = "Monoxide.MainWindow";
            this.Title = Mono.Unix.Catalog.GetString("monoXide 0.2");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child Monoxide.MainWindow.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            w1.AddUiFromString("<ui><menubar name='menubar1'><menu action='File'><menuitem action='Open'/><menuitem action='Save'/><separator/><menuitem action='Quit'/></menu><menu action='View'><menuitem action='refresh'/></menu><menu action='Tools'><menuitem action='AddinManagerAction'/><separator/></menu><menu action='Help'><menuitem action='About'/></menu></menubar></ui>");
            this.menubar1 = ((Gtk.MenuBar)(w1.GetWidget("/menubar1")));
            this.menubar1.Name = "menubar1";
            this.vbox2.Add(this.menubar1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.menubar1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            w1.AddUiFromString("<ui><toolbar name='toolbar'><toolitem action='Open'/><separator/><toolitem action='refresh'/><separator/><toolitem action='AddinManagerAction'/></toolbar></ui>");
            this.toolbar = ((Gtk.Toolbar)(w1.GetWidget("/toolbar")));
            this.toolbar.Name = "toolbar";
            this.toolbar.ShowArrow = false;
            this.toolbar.ToolbarStyle = ((Gtk.ToolbarStyle)(0));
            this.toolbar.IconSize = ((Gtk.IconSize)(3));
            this.vbox2.Add(this.toolbar);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox2[this.toolbar]));
            w4.Position = 1;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hpaned1 = new Gtk.HPaned();
            this.hpaned1.CanFocus = true;
            this.hpaned1.Name = "hpaned1";
            this.hpaned1.Position = 199;
            // Container child hpaned1.Gtk.Paned+PanedChild
            this.scrolledwindow1 = new Gtk.ScrolledWindow();
            this.scrolledwindow1.CanFocus = true;
            this.scrolledwindow1.Name = "scrolledwindow1";
            this.scrolledwindow1.VscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow1.HscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow1.Gtk.Container+ContainerChild
            this.treeview = new Gtk.TreeView();
            this.treeview.CanFocus = true;
            this.treeview.Name = "treeview";
            this.scrolledwindow1.Add(this.treeview);
            this.hpaned1.Add(this.scrolledwindow1);
            Gtk.Paned.PanedChild w6 = ((Gtk.Paned.PanedChild)(this.hpaned1[this.scrolledwindow1]));
            w6.Resize = false;
            // Container child hpaned1.Gtk.Paned+PanedChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.objectExpander = new Gtk.Expander(null);
            this.objectExpander.CanFocus = true;
            this.objectExpander.Name = "objectExpander";
            // Container child objectExpander.Gtk.Container+ContainerChild
            this.textview = new Gtk.TextView();
            this.textview.CanFocus = true;
            this.textview.Name = "textview";
            this.textview.Editable = false;
            this.objectExpander.Add(this.textview);
            this.objectLabel = new Gtk.Label();
            this.objectLabel.Name = "objectLabel";
            this.objectLabel.LabelProp = Mono.Unix.Catalog.GetString("<empty>");
            this.objectLabel.UseUnderline = true;
            this.objectExpander.LabelWidget = this.objectLabel;
            this.vbox1.Add(this.objectExpander);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox1[this.objectExpander]));
            w8.Position = 0;
            w8.Expand = false;
            w8.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.notebook = new Gtk.Notebook();
            this.notebook.CanFocus = true;
            this.notebook.Name = "notebook";
            this.notebook.CurrentPage = 0;
            this.notebook.Scrollable = true;
            // Container child notebook.Gtk.Notebook+NotebookChild
            this.scrolledwindow2 = new Gtk.ScrolledWindow();
            this.scrolledwindow2.CanFocus = true;
            this.scrolledwindow2.Name = "scrolledwindow2";
            this.scrolledwindow2.VscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow2.HscrollbarPolicy = ((Gtk.PolicyType)(1));
            this.scrolledwindow2.ShadowType = ((Gtk.ShadowType)(1));
            // Container child scrolledwindow2.Gtk.Container+ContainerChild
            Gtk.Viewport w9 = new Gtk.Viewport();
            w9.Name = "GtkViewport";
            w9.ShadowType = ((Gtk.ShadowType)(0));
            // Container child GtkViewport.Gtk.Container+ContainerChild
            this.image = new Gtk.Image();
            this.image.Name = "image";
            w9.Add(this.image);
            this.scrolledwindow2.Add(w9);
            this.notebook.Add(this.scrolledwindow2);
            Gtk.Notebook.NotebookChild w12 = ((Gtk.Notebook.NotebookChild)(this.notebook[this.scrolledwindow2]));
            w12.TabExpand = false;
            this.vbox1.Add(this.notebook);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox1[this.notebook]));
            w13.Position = 1;
            this.hpaned1.Add(this.vbox1);
            this.vbox2.Add(this.hpaned1);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox2[this.hpaned1]));
            w15.Position = 2;
            // Container child vbox2.Gtk.Box+BoxChild
            this.statusbar1 = new Gtk.Statusbar();
            this.statusbar1.Name = "statusbar1";
            this.statusbar1.Spacing = 6;
            this.vbox2.Add(this.statusbar1);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox2[this.statusbar1]));
            w16.Position = 3;
            w16.Expand = false;
            w16.Fill = false;
            this.Add(this.vbox2);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 698;
            this.DefaultHeight = 490;
            this.Show();
            this.refresh.Activated += new System.EventHandler(this.OnRefreshActivated);
            this.Quit.Activated += new System.EventHandler(this.OnQuitActivated);
            this.AddinManagerAction.Activated += new System.EventHandler(this.OnAddinManagerActivated);
            this.Open.Activated += new System.EventHandler(this.OnOpenActivated);
            this.About.Activated += new System.EventHandler(this.OnAboutActivated);
            this.Save.Activated += new System.EventHandler(this.OnSaveActivated);
            this.treeview.ButtonPressEvent += new Gtk.ButtonPressEventHandler(this.OnTreeviewButtonPressEvent);
        }
    }
}
