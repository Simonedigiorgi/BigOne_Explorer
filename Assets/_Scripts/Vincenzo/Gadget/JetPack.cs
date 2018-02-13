using Invector.CharacterController;

public class JetPack : Gadget {

    public override void EnableGadget()
    {
        base.EnableGadget();
        this.GetComponent<vThirdPersonController>().MultiJump = 2;
    }

}
