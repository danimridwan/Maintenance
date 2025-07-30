namespace MaintenanceWebApp.Data
{
    public enum PPMStatus
    {
        Request,
        ApprovedByManager,
        ApprovedByTerminalManager,
        OnProgress,
        Checking,
        Completed,
        Rejected
    }

    public enum PPMStatusLevel
    {
        // Level 0: Permintaan awal oleh Supervisor
        Request = 0,

        // Level 1: Disetujui oleh Manager, menunggu Terminal Manager
        ApprovedByManager = 1,

        // Level 2: Disetujui oleh Terminal Manager, menunggu Maintenance Supervisor menugaskan PIC
        ApprovedByTerminalManager = 2,

        // Level 3: Ditugaskan ke Maintenance PIC, sedang dalam pengerjaan
        OnProgress = 3,

        // Level 4: Diselesaikan oleh Maintenance PIC, menunggu Supervisor melakukan pengecekan
        Checking = 4,

        // Level 5: Disetujui oleh Supervisor, PPM Selesai
        Completed = 5,

        // Level 6: Ditolak di level manapun
        Rejected = 6
    }
}