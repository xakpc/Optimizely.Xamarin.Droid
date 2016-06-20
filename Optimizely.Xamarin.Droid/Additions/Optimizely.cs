namespace Com.Optimizely
{
    public partial class Optimizely
    {
        private static bool _editGestureEnabled = true;
        private static bool _visualExperimentsEnabled = true;

        public static bool EditGestureEnabled
        {
            get { return _editGestureEnabled; }
            set
            {
                SetEditGestureEnabled(value);
                _editGestureEnabled = value;
            }
        }

        public static bool VisualExperimentsEnabled
        {
            get { return _visualExperimentsEnabled; }
            set
            {
                SetVisualExperimentsEnabled(true);
                _visualExperimentsEnabled = value;
            }
        }
    }
}