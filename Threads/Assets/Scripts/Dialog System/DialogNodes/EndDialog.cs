public class EndDialog : DialogNode
{
    public EndDialog()
    {
        NodeID = "End";
    }

    public override void DisplayDialog()
    {
        DialogController.Instance.excecuteEndDialog();
    }
}
