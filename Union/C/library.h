#ifndef C_LIBRARY_H
#define C_LIBRARY_H

typedef enum _DataType {
    dtInteger,
    dtFloat
} DataType, *PDataType;

typedef union _UnionData {
    int A;
    double B;
} UnionData, *PUnionData;

typedef struct _Data {
    int A;
    double B;
    DataType DataType;
    UnionData UData;
} Data, *PData;

typedef PData(*PCreateData)();
typedef void(*PRemoveData)(PData data);

PData CreateData();
void RemoveData(PData data);

void hello(void);

#endif