public class BowlingGame
{
    List<int> record = new List<int>();
    public void Roll(int pins)
    {
        // 1. 基础范围检查
        if (pins < 0 || pins > 10)
            throw new ArgumentException();

        // 2. 检查游戏是否已经完成
        if (IsGameComplete())
            throw new ArgumentException();

        // 3. 检查本次投掷是否合法（包括普通两球和≤10，以及第十帧bonus规则）
        if (!IsValidRoll(pins))
            throw new ArgumentException();

        // 通过所有检查，记录本次投掷
        record.Add(pins);
    }

    public int? Score()
    {
        // 游戏未开始或不完整时不允许计分
        if (!IsGameComplete())
            throw new ArgumentException();

        int[] frames = new int[10];
        int frameIndex = 0;
        int extraScore = 0;
        for (int recordIndex = 0; recordIndex < record.Count; recordIndex++)
        {
            //判断是不是前9帧
            if (frameIndex == 9)
            {
                frames[frameIndex] = record.Skip(recordIndex).Sum();
                break;
            }
            //判断是全中、补中还是开放局
            //全中
            if (record[recordIndex] == 10)
            {
                frames[frameIndex] = 10;
                extraScore += record[recordIndex + 1] + record[recordIndex + 2];
                frameIndex++;
            }
            //补中
            else if (record[recordIndex] + record[recordIndex + 1] == 10)
            {
                frames[frameIndex] = 10;
                extraScore += record[recordIndex + 2];
                recordIndex++;
                frameIndex++;
            }
            //开放局
            else
            {
                frames[frameIndex] = record[recordIndex] + record[recordIndex + 1];
                recordIndex++;
                frameIndex++;
            }
        }

        return frames.Sum() + extraScore;
    }

    private bool IsGameComplete()
    {
        int totalRolls = record.Count;
        int frame = 0;
        int rollIdx = 0;

        while (frame < 10 && rollIdx < totalRolls)
        {
            if (frame < 9) // 前9帧
            {
                if (record[rollIdx] == 10) // 全中
                {
                    rollIdx++;
                    frame++;
                }
                else // 非全中，需要两次投掷
                {
                    if (rollIdx + 1 >= totalRolls) return false; // 缺少第二投
                    rollIdx += 2;
                    frame++;
                }
            }
            else // 第10帧
            {
                // 第一投
                int first = record[rollIdx];
                rollIdx++;

                if (first == 10) //  strike，需要两个奖励投掷
                {
                    if (rollIdx + 1 > totalRolls) return false; // 不足两个奖励投掷
                    // 检查奖励投掷之间的规则：当第一个奖励投掷不是全中时，第二个奖励投掷不能使两者之和超过10
                    if (rollIdx < totalRolls)
                    {
                        int second = record[rollIdx];
                        if (second != 10 && rollIdx + 1 < totalRolls)
                        {
                            int third = record[rollIdx + 1];
                            if (second + third > 10) return false; // 违反 bonus 规则
                        }
                    }
                    rollIdx += 2;
                    frame++;
                }
                else // 第一投不是全中
                {
                    if (rollIdx >= totalRolls) return false; // 缺少第二投
                    int second = record[rollIdx];
                    rollIdx++;

                    if (first + second == 10) // spare，需要一个奖励投掷
                    {
                        if (rollIdx >= totalRolls) return false; // 缺少奖励投掷
                        rollIdx++;
                    }
                    // 开放局，不需要奖励投掷
                    frame++;
                }
                break; // 第10帧处理完即结束
            }
        }

        // 必须恰好完成10帧，并且所有需要的投掷都已使用
        return frame == 10 && rollIdx == totalRolls;
    }

    // 检查即将投出的值是否符合第十帧的 bonus 规则（如果当前正处于 bonus 阶段）
    // 检查本次投掷是否合法（包含普通两球和≤10，以及第十帧bonus规则）
    private bool IsValidRoll(int pins)
    {
        int totalRolls = record.Count;
        int frame = 0;
        int rollIdx = 0;

        while (frame < 10 && rollIdx < totalRolls)
        {
            if (frame < 9)
            {
                if (record[rollIdx] == 10)
                {
                    rollIdx++;
                    frame++;
                }
                else
                {
                    if (rollIdx + 1 >= totalRolls) // 当前帧只有第一投，等待第二投
                    {
                        // 检查第二投是否使该帧总和超过10
                        if (record[rollIdx] + pins > 10)
                            return false;
                        return true; // 合法
                    }
                    else
                    {
                        rollIdx += 2;
                        frame++;
                    }
                }
            }
            else // 第10帧
            {
                int first = record[rollIdx];
                rollIdx++;

                if (first == 10) // strike
                {
                    if (rollIdx >= totalRolls) // 第一个bonus
                        return true;
                    else if (rollIdx + 1 >= totalRolls) // 第二个bonus
                    {
                        int firstBonus = record[rollIdx];
                        if (firstBonus != 10 && pins + firstBonus > 10)
                            return false;
                        return true;
                    }
                    else // 两个bonus已存在
                        return false;
                }
                else // 第一投不是全中
                {
                    if (rollIdx >= totalRolls) // 第二投
                    {
                        // 检查两球和是否超过10
                        if (first + pins > 10)
                            return false;
                        return true;
                    }
                    else
                    {
                        int second = record[rollIdx];
                        rollIdx++;
                        if (first + second == 10) // spare，需要bonus
                        {
                            if (rollIdx >= totalRolls) // 等待bonus
                                return true;
                            else
                                return false; // bonus已存在，游戏完整
                        }
                        else // 开放局，游戏完整
                        {
                            return false;
                        }
                    }
                }
            }
        }

        // 尚未进入任何不完整帧（新的一局第一投总是合法）
        return true;
    }
}