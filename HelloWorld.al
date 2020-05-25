// Welcome to your new AL extension.
// Remember that object names and IDs should be unique across all extensions.
// AL snippets start with t*, like tpageext - give them a try and happy coding!

pageextension 63000 CustomerListExt extends "Customer List"
{
    actions
    {
        addafter("&Customer")
        {
            action(BlobTest)
            {
                ApplicationArea = All;
                Caption = 'Blob test';
                Promoted = true;
                PromotedIsBig = true;
                trigger OnAction()
                var
                    BLOBStorageMgmt: Codeunit "BLOB Storge Mgmt.";
                begin
                    BLOBStorageMgmt.UploadFile('c:\Temp\test.xml', 'test.xml', 'input', true);

                end;
            }
            action(Dotnettypetest)
            {
                ApplicationArea = All;
                Caption = 'DotNet Datatype test';
                Promoted = true;
                PromotedIsBig = true;
                trigger OnAction()
                var
                    var1: DotNet DataTable;
                begin
                    var1 := var1;
                    var1.Clear();

                end;
            }
        }
    }

    trigger OnOpenPage();
    begin

    end;



}