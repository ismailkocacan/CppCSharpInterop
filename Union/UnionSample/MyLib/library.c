#include <stdio.h>
#include <stdlib.h>
#include "library.h"

DllExport PData CreateData() {
    PData pData = malloc(sizeof(Data));
    pData->FieldInteger = 35;
    pData->FieldDouble = 38.1;
    /* UnionData alanlarına erişirken,
       DataType değerine göre kontrol edip okuyacağız.
    */
    pData->DataType = DT_DOUBLE;
    pData->UnionData.FieldDouble = 31.32;
    return pData;
}

DllExport void RemoveData(PData data) {
   free(data);
}