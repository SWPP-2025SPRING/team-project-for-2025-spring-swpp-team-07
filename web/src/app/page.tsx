import { PlayerData } from "@/entities/player-data";
import mongodb, { ObjectId, ServerApiVersion } from "mongodb";

export default async function Home() {
  const mongodbUrl = `mongodb+srv://woohm404:${process.env.MONGODB_PASSWORD}@cluster0.qtwt5z8.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0`;
  const client = await mongodb.MongoClient.connect(mongodbUrl, {
    serverApi: ServerApiVersion.v1,
  });

  const data = (await client
    .db("player-data")
    .collection("players")
    .find()
    .toArray()) as ({ _id: ObjectId } & PlayerData)[];

  return (
    <ul className="flex flex-col py-12 px-6">
      {data.map((item, i) => (
        <li
          key={item._id.toString()}
          className="shadow-lg rounded-xl px-4 py-3 border border-gray-300 flex items-center gap-4"
        >
          <div className="text-2xl flex-1">{i + 1}등</div>
          <dl className="grid grid-cols-[1fr_auto] gap-x-3">
            <dt>닉네임</dt>
            <dd>{item.nickname}</dd>
            <dt>고른 증강 목록</dt>
            <dd>{JSON.stringify(item.augmentIds)}</dd>
            <dt>총 소요 시간</dt>
            <dd>{item.totalTime}초</dd>
          </dl>
        </li>
      ))}
    </ul>
  );
}
