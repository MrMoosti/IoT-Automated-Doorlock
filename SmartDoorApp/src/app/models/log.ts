export enum AttemptType {
  Success,
  Fail,
  UnkownUid,
  Error
}

export class Log {
  bsonId: string;
  addedAtUtc: string;
  uid: {};
  attemptType: AttemptType;
  message: string;
}
