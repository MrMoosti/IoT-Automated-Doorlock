export enum AttemptType {
  Success,
  Fail,
  UnkownUid,
  Error
}

export class Log {
  bsonId: string;
  unixTime: number;
  uid: {};
  attemptType: AttemptType;
  message: string;
}
