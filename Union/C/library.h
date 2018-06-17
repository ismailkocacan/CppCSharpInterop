#ifndef C_LIBRARY_H
#define C_LIBRARY_H

typedef enum _DataType {
    DT_INTEGER,
    DT_DOUBLE
} DataType, *PDataType;

typedef union _UnionData {
    int FieldInteger;
    double FieldDouble;
} UnionData, *PUnionData;

typedef struct _Data {
    int FieldInteger;
    double FieldDouble;
    DataType DataType;
    UnionData UnionData;
} Data, *PData;

typedef PData(*PCreateData)();
typedef void(*PRemoveData)(PData data);

PData CreateData();
void RemoveData(PData data);

void hello(void);

#endif