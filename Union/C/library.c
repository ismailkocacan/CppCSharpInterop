#include <stdio.h>
#include <stdlib.h>
#include "library.h"

PData CreateData() {
    PData pData = malloc(sizeof(Data));
    pData->A = 35;
    pData->DataType = dtFloat;
    pData->UData.B = 31.32;
    return pData;
}

void RemoveData(PData data) {
   free(data);
}

void hello(void) {
    printf("Hello, World!\n");
}