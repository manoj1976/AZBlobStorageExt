dotnet
{
    assembly(BLOBStorageMgmt)
    {
        type(BLOBStorageMgmt.BLOBStorageMgmt) { }
    }
}
codeunit 63000 "BLOB Storge Mgmt."
{

    procedure UploadFile(SourceFileName: Text; DestFileName: Text; ContainerName: Text; ShowSuccessMsg: Boolean)
    begin
        _UploadFileToAZBlobStorage(SourceFileName, DestFileName, ContainerName, ShowSuccessMsg);
    end;

    procedure DownloadFile(SourceFileName: Text; DestFileName: Text; ContainerName: Text; ShowSuccessMsg: Boolean)
    begin
        _DownloadFile(SourceFileName, DestFileName, ContainerName, ShowSuccessMsg);
    end;

    procedure DownloadAndDeleteFile(SourceFileName: Text; DestFileName: Text; ContainerName: Text; ShowSuccessMsg: Boolean)
    begin
        _DownloadFile(SourceFileName, DestFileName, ContainerName, ShowSuccessMsg);
    end;

    local procedure _UploadFileToAZBlobStorage(SourceFileName: Text; DestFileName: Text; ContainerName: Text; ShowSuccessMsg: Boolean)
    var
        BLOBStorageMgmt: DotNet BLOBStorageMgmt;
    begin
        BLOBStorageMgmt := BLOBStorageMgmt.BLOBStorageMgmt('DefaultEndpointsProtocol=https;AccountName=manojstorageac;AccountKey=oof6WRupsTtJZcYDv7+zsRHGKsP2aMAi2HhD6p5OozGuI/A0JAGB96307nQjRhClc9m0KYj54To3zMjIaEublA==;EndpointSuffix=core.windows.net');
        BLOBStorageMgmt.UploadFile(SourceFileName, DestFileName, ContainerName);
        if GuiAllowed then
            if ShowSuccessMsg then
                Message('The file is uploaded successfully.');
    end;

    local procedure _DownloadFile(SourceFileName: Text; DestFileName: Text; ContainerName: Text; ShowSuccessMsg: Boolean)
    var
        BLOBStorageMgmt: DotNet BLOBStorageMgmt;
    begin
        BLOBStorageMgmt := BLOBStorageMgmt.BLOBStorageMgmt('DefaultEndpointsProtocol=https;AccountName=manojstorageac;AccountKey=oof6WRupsTtJZcYDv7+zsRHGKsP2aMAi2HhD6p5OozGuI/A0JAGB96307nQjRhClc9m0KYj54To3zMjIaEublA==;EndpointSuffix=core.windows.net');
        BLOBStorageMgmt.DownloadFile(SourceFileName, DestFileName, ContainerName);
        if GuiAllowed then
            if ShowSuccessMsg then
                Message('The file is downloaded successfully.');
    end;

    local procedure _DownloadAndDeleteFile(SourceFileName: Text; DestFileName: Text; ContainerName: Text; ShowSuccessMsg: Boolean)
    var
        BLOBStorageMgmt: DotNet BLOBStorageMgmt;
    begin
        BLOBStorageMgmt := BLOBStorageMgmt.BLOBStorageMgmt('DefaultEndpointsProtocol=https;AccountName=manojstorageac;AccountKey=oof6WRupsTtJZcYDv7+zsRHGKsP2aMAi2HhD6p5OozGuI/A0JAGB96307nQjRhClc9m0KYj54To3zMjIaEublA==;EndpointSuffix=core.windows.net');
        //BLOBStorageMgmt.dlo(SourceFileName, DestFileName, ContainerName);
        if GuiAllowed then
            if ShowSuccessMsg then
                Message('The file is downloaded successfully.');
    end;

}