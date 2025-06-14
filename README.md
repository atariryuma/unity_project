# 3Dゲーム開発環境の構築手順

このリポジトリは、Unity を使用した 3D ゲーム開発を始めるための基本的な環境構築手順をまとめたものです。以下の手順に従って開発を始める準備を行ってください。

## 1. Unity Hub のインストール
1. [公式サイト](https://unity.com/) から Unity Hub をダウンロードしてインストールします。
2. Unity Hub を起動し、サインインします。
3. 新しいバージョンの Unity エディターをインストールします。LTS 版 (Long Term Support) を選択すると安定性が高くおすすめです。

## 2. IDE の準備
Unity では以下の IDE のいずれかを使うことを推奨します。
- **Visual Studio** (Windows/Mac)
  - Unity Hub からインストールする際に "Microsoft Visual Studio" を選択すると自動的にセットアップされます。
- **Rider (JetBrains)**
  - 有料ですが、C# の開発体験が向上します。必要に応じて [公式サイト](https://www.jetbrains.com/rider/) からインストールしてください。
- **Visual Studio Code**
  - 軽量なエディタを好む場合はこちらを利用します。C# 拡張機能をインストールすることで Unity 開発に対応できます。

## 3. 新規プロジェクトの作成
1. Unity Hub を起動し、`Projects` タブから `New project` を選択します。
2. テンプレート一覧から `3D (HDRP)` もしくは `3D Core` を選択します。
3. プロジェクト名と保存場所を設定して `Create project` をクリックします。

## 4. バージョン管理
ゲーム開発では Git を用いたバージョン管理が推奨されます。このリポジトリは空の Unity プロジェクト用として準備されています。新規プロジェクトを作成したら以下のようにコミットします。

```bash
# 初回だけ
git init

# Unity の .gitignore を取得
curl -o .gitignore https://raw.githubusercontent.com/github/gitignore/main/Unity.gitignore

# 生成されたファイルを追加
git add .

git commit -m "Add initial Unity project"
```

## 5. ビルド設定
1. Unity エディター上部の `File > Build Settings` を開きます。
2. 対応プラットフォームを選び `Switch Platform` をクリックします。
3. `Add Open Scenes` を押して現在のシーンを追加し、`Build` もしくは `Build and Run` でビルドします。

## 6. 参考リンク
- [Unity Learn](https://learn.unity.com/)
- [Unity マニュアル](https://docs.unity3d.com/ja/current/Manual/)

以上で 3D ゲーム開発を始めるための環境構築は完了です。

## 7. このリポジトリについて
このリポジトリには Unity 2023 向けの簡易的な 3D FPS プロジェクトの雛形が含まれています。
`Assets/Scenes/Main.unity` を開き、`Assets/Scripts` 以下の C# スクリプトを編集してゲームを拡張してください。
Visual Studio Code を使用する場合は `.vscode/extensions.json` の推奨拡張機能をインストールすると便利です。
